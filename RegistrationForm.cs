using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            string validationMessage = ValidateRegistration(
                username, password, confirmPassword, email, fullName);

            if (validationMessage != null)
            {
                MessageBox.Show(this, validationMessage, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (DatabaseHelper.UsernameExists(username))
                {
                    MessageBox.Show(this, "Username already taken", "Registration Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                    return;
                }

                DatabaseHelper.RegisterUser(username, password, email, fullName);

                MessageBox.Show(this,
                    "Registration successful. You can now log in.",
                    "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show(this, "Username already taken", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.SelectAll();
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Registration could not be completed. Check the database connection and try again.\n\n" +
                    "Technical detail: " + ex.Message,
                    "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ValidateRegistration(
            string username,
            string password,
            string confirmPassword,
            string email,
            string fullName)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(fullName))
            {
                return "All fields are required.";
            }

            if (username.Length > 50)
            {
                return "Username cannot be longer than 50 characters.";
            }

            if (password.Length < 6)
            {
                return "Password must be at least 6 characters long.";
            }

            if (!string.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                return "Password and Confirm Password do not match.";
            }

            if (!email.Contains("@"))
            {
                return "Enter a valid email address containing @.";
            }

            if (email.Length > 100 || fullName.Length > 100)
            {
                return "Email and Full Name must each be 100 characters or fewer.";
            }

            return null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtEmail.Clear();
            txtFullName.Clear();
        }
    }
}
