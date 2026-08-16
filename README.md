# 24-58158-2 Login System

- **Student:** MD. Nazmus Sakib
- **Student ID:** 24-58158-2
- **Course:** OOP 2 (Lab)
- **Assignment:** Login, Registration & Logout with C# and SQL Server

This is a new Windows Forms application built for Lab Task 1. 

## 1. Environment

- **IDE:** Visual Studio 2026 Community
- **Framework:** .NET Framework 4.8
- **Database engine:** Microsoft SQL Server LocalDB (`MSSQLLocalDB`)
- **Database tools:** SQL Server Management Studio (SSMS) or Visual Studio SQL Server Object Explorer
- **ADO.NET provider:** `System.Data.SqlClient`
- **Connection-string format:** Windows Integrated Security; no SQL username or password is committed

The connection string is stored once in `App.config`:

```xml
<add name="LoginDb"
     providerName="System.Data.SqlClient"
     connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=24-58158-2_LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" />
```



## 2.Setup and Running the software

1. Start LocalDB if needed:

   ```powershell
   sqllocaldb start MSSQLLocalDB
   ```

2. Open SSMS and connect to server with `(localdb)\MSSQLLocalDB` or the pipeline name with Windows Authentication.
3. Open `Schema.sql` and run the complete script. It creates `24-58158-2_LoginDB`, `dbo.Users`, and the bonus `dbo.LoginHistory` table.
4. Open `24-58158-2_LoginSystem.sln` in Visual Studio 2022.
5. Confirm that the project targets .NET Framework 4.8 and that the `System.Configuration` reference exists.
6. Build the solution, then run it with `F5`.
7. On the Login form, use **Test connection** before registering the first user.



## 3. Database design

`Schema.sql` creates the required `dbo.Users` table with:

- `UserID INT IDENTITY(1,1) PRIMARY KEY`
- `Username NVARCHAR(50) NOT NULL UNIQUE`
- `PasswordHash NVARCHAR(200) NOT NULL`
- `Email NVARCHAR(100)`
- `FullName NVARCHAR(100)`
- `CreatedAt DATETIME DEFAULT GETDATE()`

The script also creates `dbo.LoginHistory` for the selected bonus task. `LoginHistory.UserID` is a foreign key to `Users.UserID`; every successful login records `LoginTime`, and logout fills `LogoutTime`.

## 4. How my code works

### Registration

`RegistrationForm.btnRegister_Click` reads Username, Password, Confirm Password, Email, and Full Name. `ValidateRegistration` rejects empty fields, passwords shorter than six characters, mismatched passwords, and email values without `@`.

`DatabaseHelper.UsernameExists` uses `ExecuteScalar()` with `@Username`. If the count is greater than zero, the form shows **Username already taken**. Otherwise, `DatabaseHelper.RegisterUser` hashes the password and inserts one row with a parameterized `ExecuteNonQuery()`. After success, the form shows a confirmation, clears every field, closes, and returns to the Login form.

### Login

`LoginForm.btnLogin_Click` calls `DatabaseHelper.AuthenticateUser`. That method uses a parameterized `SqlDataReader` query to retrieve one user by username. The entered password is hashed and compared with the stored hash; the original password is never read from or written to the database.

On success, the Login form is cleared and hidden, and `HomeForm` opens modally with **Welcome, {FullName}**. On failure, the password field is cleared and the remaining-attempt count is shown. After three failed attempts, `btnLogin.Enabled` becomes `false`.

### Home screen and user grid

`HomeForm.LoadUsersGrid` calls `DatabaseHelper.GetUsers`. A `SqlDataAdapter` fills a `DataTable`, which becomes the `DataSource` of `dgvUsers`. The query returns only `UserID`, `Username`, `Email`, and `CreatedAt`; it never selects or displays `PasswordHash`.

### Logout and form lifecycle

`Program.Main` runs exactly one main form: `LoginForm`. Login hides that form and opens one modal `HomeForm`. Clicking Logout records the logout time and closes only `HomeForm`; execution then returns to the existing Login form, which is shown with empty fields and focus on `txtUsername`. This prevents both accidental application exit and orphan forms. Closing the Home form with its X is also treated as logout.

### Connection safety

All database access is in `DatabaseHelper`. Forms never create a `SqlConnection`. Every `SqlConnection`, `SqlCommand`, `SqlDataReader`, and `SqlDataAdapter` is placed in a `using` block so it is disposed even if an exception occurs. Form event handlers catch connection errors and show friendly messages.

## 5. Password hashing

`PasswordHasher.HashPassword` uses SHA-256 and stores a 64-character hexadecimal hash. At login, `VerifyPassword` hashes the entered password again and compares the two hashes. Plain-text storage is unacceptable because anyone who reads the database, backup, or log would immediately learn every user's real password.

SHA-256 satisfies this lab's minimum requirement. For a production application, I would use a unique salt and a deliberately slow password-hashing algorithm such as PBKDF2, bcrypt, scrypt, or Argon2.

## 6. SQL injection demonstration

### Vulnerable version - demonstration only, never compiled

The supplied sample constructed SQL by joining control values into the command text. 
```csharp
// INSECURE DEMONSTRATION ONLY - not present in any .cs source file
string unsafeSql = "SELECT Username FROM dbo.Users WHERE Username='"
    + enteredUsername + "' AND Password='" + enteredPassword + "'";
```

With username `x` and password `' OR '1'='1`, the condition contains an always-true expression. A concatenated implementation can therefore return rows without the correct password.

### Fixed code used by this project

```csharp
const string userSql = @"SELECT TOP (1)
                             UserID, Username, PasswordHash, FullName
                         FROM dbo.Users
                         WHERE Username = @Username;";

using (SqlCommand command = new SqlCommand(userSql, connection))
{
    command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
    // ExecuteReader(), then hash and compare the entered password in C#.
}
```

Parameters send the value separately from the SQL command text, so SQL Server treats quote characters as ordinary data rather than executable syntax. In this implementation the password is not inserted into SQL at all: the entered value is hashed and compared with `PasswordHash`, so `' OR '1'='1` is simply a wrong password.

## 7. Bonus tasks completed

1. **DatabaseHelper class:** all SQL code was moved out of the forms. Forms never touch `SqlConnection` directly.
2. **LoginHistory:** a foreign-key table records a row after successful authentication and stamps `LogoutTime` when HomeForm closes.

## 8. Problems found and how I solved them

- The sample used two different hard-coded database names. I created one database and one named connection string in `App.config`.
- The sample queried `LoginMst`, while its script created `[dbo].[Table]`. I made the schema and every query consistently use `dbo.Users`.
- The sample referenced an unused old `MySql.Data.dll`. My project uses only SQL Server's `System.Data.SqlClient`.
- The sample leaked a connection in `Form1_Load`. My project opens connections only when needed and disposes them with `using`.
- The sample compared plain-text passwords. My project stores and compares SHA-256 hashes.
- A naïve sequence of `new LoginForm()` and `Hide()` can leave orphan forms. I kept LoginForm as the single application form and opened HomeForm modally.
- A duplicate username can still occur between the existence check and insert. The database UNIQUE constraint remains the final protection, and error numbers 2601/2627 are caught to show a friendly message.



## 10. ADO.NET patterns demonstrated

| Class / method | Use in this project |
|---|---|
| `SqlConnection` | Opens the connection described in `App.config` |
| `SqlCommand` | Holds parameterized SQL and parameters |
| `ExecuteNonQuery()` | Registration insert and logout update |
| `ExecuteScalar()` | Duplicate-username count and inserted LoginHistory ID |
| `SqlDataReader` | Reads the matching user for login |
| `SqlDataAdapter` | Loads the registered-user grid |
| `DataTable` | Holds grid data in memory |

## 11. Screenshot evidence


1. `01_table_design.png` - SSMS/Object Explorer Users column list
2. `02_registration.png` - completed Registration form before clicking Register
3. `03_successful_login.png` - successful login / welcome screen
4. `04_failed_login.png` - incorrect-password message or remaining-attempt state



