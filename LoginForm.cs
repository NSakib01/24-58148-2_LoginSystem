using System;
using System.Drawing;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    public partial class LoginForm : Form
    {
        private const int MaximumFailedAttempts = 3;
        private int failedAttempts;

        public LoginForm()
        {
            InitializeComponent();
            UpdateAttemptStatus();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            ClearLoginForm();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(this, "Enter both username and password.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                UserSession session = DatabaseHelper.AuthenticateUser(username, password);

                if (session == null)
                {
                    RegisterFailedAttempt();
                    return;
                }

                failedAttempts = 0;
                btnLogin.Enabled = true;
                UpdateAttemptStatus();
                ClearLoginForm();

                Hide();
                using (HomeForm homeForm = new HomeForm(session))
                {
                    homeForm.ShowDialog(this);
                }

                Show();
                ClearLoginForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Login could not be completed. Check the database connection and try again.\n\n" +
                    "Technical detail: " + ex.Message,
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterFailedAttempt()
        {
            failedAttempts++;
            int remainingAttempts = MaximumFailedAttempts - failedAttempts;

            if (remainingAttempts <= 0)
            {
                btnLogin.Enabled = false;
                MessageBox.Show(this,
                    "Login failed three times. The Login button is now disabled for this session.",
                    "Login Disabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this,
                    "Incorrect username or password. Attempts remaining: " + remainingAttempts + ".",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtPassword.Clear();
            txtPassword.Focus();
            UpdateAttemptStatus();
        }

        private void UpdateAttemptStatus()
        {
            int remainingAttempts = Math.Max(0, MaximumFailedAttempts - failedAttempts);
            lblAttemptStatus.Text = "Login attempts remaining: " + remainingAttempts;
            lblAttemptStatus.ForeColor = remainingAttempts == 0
                ? Color.FromArgb(185, 28, 28)
                : Color.FromArgb(100, 116, 139);
        }

        private void btnOpenRegistration_Click(object sender, EventArgs e)
        {
            using (RegistrationForm registrationForm = new RegistrationForm())
            {
                if (registrationForm.ShowDialog(this) == DialogResult.OK)
                {
                    failedAttempts = 0;
                    btnLogin.Enabled = true;
                    UpdateAttemptStatus();
                    ClearLoginForm();
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            DatabaseHelper.TestConnection(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearLoginForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
