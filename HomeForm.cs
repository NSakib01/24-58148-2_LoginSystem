using System;
using System.Data;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    public partial class HomeForm : Form
    {
        private readonly UserSession session;
        private bool logoutRecorded;

        internal HomeForm(UserSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.session = session;
            InitializeComponent();
            lblWelcome.Text = "Welcome, " + session.FullName;
            lblSignedInAs.Text = "Signed in as @" + session.Username;
        }

        private void HomeForm_Shown(object sender, EventArgs e)
        {
            LoadUsersGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsersGrid();
        }

        private void LoadUsersGrid()
        {
            try
            {
                DataTable users = DatabaseHelper.GetUsers();
                dgvUsers.DataSource = users;
                lblUserCount.Text = users.Rows.Count +
                    (users.Rows.Count == 1 ? " registered user" : " registered users");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "The user list could not be loaded.\n\nTechnical detail: " + ex.Message,
                    "Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            RecordLogoutSafely();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Closing the X is treated as logout too. The hidden LoginForm remains
            // the application's main form and becomes visible after this form closes.
            RecordLogoutSafely();
        }

        private void RecordLogoutSafely()
        {
            if (logoutRecorded)
            {
                return;
            }

            try
            {
                DatabaseHelper.RecordLogout(session.LoginHistoryId);
                logoutRecorded = true;
            }
            catch (Exception ex)
            {
                // A database outage must not trap the user on the Home screen.
                logoutRecorded = true;
                MessageBox.Show(this,
                    "You will be returned to Login, but the logout timestamp could not be saved.\n\n" +
                    "Technical detail: " + ex.Message,
                    "Logout Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
