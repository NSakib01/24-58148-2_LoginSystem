using System.Drawing;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlCard;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblEmail;
        private Label lblFullName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private Button btnRegister;
        private Button btnCancel;

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
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblConfirmPassword = new Label();
            this.lblEmail = new Label();
            this.lblFullName = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.txtEmail = new TextBox();
            this.txtFullName = new TextBox();
            this.btnRegister = new Button();
            this.btnCancel = new Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblFullName);
            this.pnlCard.Controls.Add(this.txtFullName);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblEmail);
            this.pnlCard.Controls.Add(this.txtEmail);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblConfirmPassword);
            this.pnlCard.Controls.Add(this.txtConfirmPassword);
            this.pnlCard.Controls.Add(this.btnRegister);
            this.pnlCard.Controls.Add(this.btnCancel);
            this.pnlCard.Location = new Point(47, 28);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new Size(446, 596);
            this.pnlCard.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new Point(36, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(282, 42);
            this.lblTitle.Text = "Create your account";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new Point(40, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(277, 19);
            this.lblSubtitle.Text = "Your password will be stored only as a hash.";
            //
            // lblFullName
            //
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblFullName.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblFullName.Location = new Point(40, 117);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new Size(68, 17);
            this.lblFullName.Text = "Full Name";
            //
            // txtFullName
            //
            this.txtFullName.Font = new Font("Segoe UI", 11F);
            this.txtFullName.Location = new Point(43, 138);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new Size(360, 27);
            this.txtFullName.TabIndex = 0;
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblUsername.Location = new Point(40, 180);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(68, 17);
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.Font = new Font("Segoe UI", 11F);
            this.txtUsername.Location = new Point(43, 201);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(360, 27);
            this.txtUsername.TabIndex = 1;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblEmail.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblEmail.Location = new Point(40, 243);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 17);
            this.lblEmail.Text = "Email";
            //
            // txtEmail
            //
            this.txtEmail.Font = new Font("Segoe UI", 11F);
            this.txtEmail.Location = new Point(43, 264);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(360, 27);
            this.txtEmail.TabIndex = 2;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblPassword.Location = new Point(40, 306);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(139, 17);
            this.lblPassword.Text = "Password (6+ characters)";
            //
            // txtPassword
            //
            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.Location = new Point(43, 327);
            this.txtPassword.MaxLength = 128;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new Size(360, 27);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblConfirmPassword.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblConfirmPassword.Location = new Point(40, 369);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(115, 17);
            this.lblConfirmPassword.Text = "Confirm Password";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            this.txtConfirmPassword.Location = new Point(43, 390);
            this.txtConfirmPassword.MaxLength = 128;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new Size(360, 27);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            //
            // btnRegister
            //
            this.btnRegister.BackColor = Color.FromArgb(37, 99, 235);
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.Location = new Point(43, 453);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(360, 42);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = Color.FromArgb(241, 245, 249);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.FromArgb(51, 65, 85);
            this.btnCancel.Location = new Point(43, 509);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(360, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Back to login";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // RegistrationForm
            //
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(226, 232, 240);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(540, 652);
            this.Controls.Add(this.pnlCard);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Registration - 24-58158-2";
            this.Shown += new System.EventHandler(this.RegistrationForm_Shown);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
