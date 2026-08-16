using System.Drawing;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlCard;
        private Label lblBrand;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblAttemptStatus;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnOpenRegistration;
        private Button btnTestConnection;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new Panel();
            this.lblBrand = new Label();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblAttemptStatus = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnOpenRegistration = new Button();
            this.btnTestConnection = new Button();
            this.btnExit = new Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.Controls.Add(this.lblBrand);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblAttemptStatus);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.btnOpenRegistration);
            this.pnlCard.Controls.Add(this.btnTestConnection);
            this.pnlCard.Controls.Add(this.btnExit);
            this.pnlCard.Location = new Point(64, 34);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new Padding(36);
            this.pnlCard.Size = new Size(392, 522);
            this.pnlCard.TabIndex = 0;
            //
            // lblBrand
            //
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblBrand.ForeColor = Color.FromArgb(37, 99, 235);
            this.lblBrand.Location = new Point(36, 28);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new Size(157, 19);
            this.lblBrand.Text = "SAKIB ACCOUNT PORTAL";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new Point(32, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(182, 45);
            this.lblTitle.Text = "Welcome back";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new Point(36, 108);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(244, 19);
            this.lblSubtitle.Text = "Sign in to continue to your dashboard.";
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblUsername.Location = new Point(36, 153);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(68, 17);
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.Font = new Font("Segoe UI", 11F);
            this.txtUsername.Location = new Point(39, 176);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(314, 27);
            this.txtUsername.TabIndex = 0;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblPassword.Location = new Point(36, 221);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(66, 17);
            this.lblPassword.Text = "Password";
            //
            // txtPassword
            //
            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.Location = new Point(39, 244);
            this.txtPassword.MaxLength = 128;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new Size(314, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // lblAttemptStatus
            //
            this.lblAttemptStatus.AutoSize = true;
            this.lblAttemptStatus.Font = new Font("Segoe UI", 9F);
            this.lblAttemptStatus.Location = new Point(36, 280);
            this.lblAttemptStatus.Name = "lblAttemptStatus";
            this.lblAttemptStatus.Size = new Size(165, 15);
            this.lblAttemptStatus.Text = "Login attempts remaining: 3";
            //
            // btnLogin
            //
            this.btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(39, 313);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(314, 42);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            //
            // btnOpenRegistration
            //
            this.btnOpenRegistration.BackColor = Color.White;
            this.btnOpenRegistration.Cursor = Cursors.Hand;
            this.btnOpenRegistration.FlatStyle = FlatStyle.Flat;
            this.btnOpenRegistration.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.btnOpenRegistration.ForeColor = Color.FromArgb(37, 99, 235);
            this.btnOpenRegistration.Location = new Point(39, 366);
            this.btnOpenRegistration.Name = "btnOpenRegistration";
            this.btnOpenRegistration.Size = new Size(314, 38);
            this.btnOpenRegistration.TabIndex = 3;
            this.btnOpenRegistration.Text = "Create a new account";
            this.btnOpenRegistration.UseVisualStyleBackColor = false;
            this.btnOpenRegistration.Click += new System.EventHandler(this.btnOpenRegistration_Click);
            //
            // btnTestConnection
            //
            this.btnTestConnection.BackColor = Color.FromArgb(241, 245, 249);
            this.btnTestConnection.FlatAppearance.BorderSize = 0;
            this.btnTestConnection.FlatStyle = FlatStyle.Flat;
            this.btnTestConnection.Font = new Font("Segoe UI", 9F);
            this.btnTestConnection.ForeColor = Color.FromArgb(51, 65, 85);
            this.btnTestConnection.Location = new Point(39, 423);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new Size(152, 34);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            //
            // btnExit
            //
            this.btnExit.BackColor = Color.FromArgb(241, 245, 249);
            this.btnExit.DialogResult = DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.Font = new Font("Segoe UI", 9F);
            this.btnExit.ForeColor = Color.FromArgb(51, 65, 85);
            this.btnExit.Location = new Point(201, 423);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(152, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            //
            // LoginForm
            //
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(226, 232, 240);
            this.CancelButton = this.btnExit;
            this.ClientSize = new Size(520, 590);
            this.Controls.Add(this.pnlCard);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login System - 24-58158-2";
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
