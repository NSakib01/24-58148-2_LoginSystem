using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    /// <summary>
    /// Bonus task: all SQL Server access is centralized here.
    /// Forms call methods in this class and never create SqlConnection objects.
    /// </summary>
    internal static class DatabaseHelper
    {
        private static string ConnectionString
        {
            get
            {
                ConnectionStringSettings setting =
                    ConfigurationManager.ConnectionStrings["LoginDb"];

                if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                {
                    throw new ConfigurationErrorsException(
                        "The LoginDb connection string is missing from App.config.");
                }

                return setting.ConnectionString;
            }
        }

        /// <summary>
        /// Opens and automatically closes a connection. Any connection problem is
        /// shown as a friendly message instead of crashing the application.
        /// </summary>
        public static bool TestConnection()
        {
            return TestConnection(null);
        }

        public static bool TestConnection(IWin32Window owner)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                }

                MessageBox.Show(owner, "Database connection successful.", "Connection Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner,
                    "Could not connect to SQL Server. Check that LocalDB is running, " +
                    "the database exists, and App.config has the correct Data Source.\n\n" +
                    "Technical detail: " + ex.Message,
                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool UsernameExists(string username)
        {
            const string sql =
                "SELECT COUNT(*) FROM dbo.Users WHERE Username = @Username;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public static void RegisterUser(
            string username,
            string password,
            string email,
            string fullName)
        {
            const string sql = @"INSERT INTO dbo.Users
                                 (Username, PasswordHash, Email, FullName)
                                 VALUES
                                 (@Username, @PasswordHash, @Email, @FullName);";

            string passwordHash = PasswordHasher.HashPassword(password);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 200).Value = passwordHash;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                command.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = fullName;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected != 1)
                {
                    throw new DataException("Registration did not create exactly one user.");
                }
            }
        }

        public static UserSession AuthenticateUser(string username, string password)
        {
            const string userSql = @"SELECT TOP (1)
                                         UserID, Username, PasswordHash, FullName
                                     FROM dbo.Users
                                     WHERE Username = @Username;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(userSql, connection))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                connection.Open();

                int userId;
                string storedUsername;
                string storedHash;
                string fullName;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    userId = reader.GetInt32(reader.GetOrdinal("UserID"));
                    storedUsername = reader.GetString(reader.GetOrdinal("Username"));
                    storedHash = reader.GetString(reader.GetOrdinal("PasswordHash"));

                    int fullNameIndex = reader.GetOrdinal("FullName");
                    fullName = reader.IsDBNull(fullNameIndex)
                        ? storedUsername
                        : reader.GetString(fullNameIndex);
                }

                if (!PasswordHasher.VerifyPassword(password, storedHash))
                {
                    return null;
                }

                UserSession session = new UserSession(userId, storedUsername, fullName);
                session.LoginHistoryId = InsertLoginHistory(connection, userId);
                return session;
            }
        }

        private static int InsertLoginHistory(SqlConnection openConnection, int userId)
        {
            const string sql = @"INSERT INTO dbo.LoginHistory (UserID, LoginTime)
                                 OUTPUT INSERTED.HistoryID
                                 VALUES (@UserID, GETDATE());";

            using (SqlCommand command = new SqlCommand(sql, openConnection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static void RecordLogout(int loginHistoryId)
        {
            if (loginHistoryId <= 0)
            {
                return;
            }

            const string sql = @"UPDATE dbo.LoginHistory
                                 SET LogoutTime = GETDATE()
                                 WHERE HistoryID = @HistoryID
                                   AND LogoutTime IS NULL;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@HistoryID", SqlDbType.Int).Value = loginHistoryId;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetUsers()
        {
            const string sql = @"SELECT UserID, Username, Email, CreatedAt
                                 FROM dbo.Users
                                 ORDER BY UserID;";

            DataTable usersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(usersTable);
            }

            return usersTable;
        }
    }
}
