using System.Drawing;
using System.Windows.Forms;

namespace ID_24_58158_2_LoginSystem
{
    partial class HomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblAppName;
        private Label lblWelcome;
        private Label lblSignedInAs;
        private Label lblSectionTitle;
        private Label lblGridNote;
        private Label lblUserCount;
        private Button btnRefresh;
        private Button btnLogout;
        private DataGridView dgvUsers;

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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            this.pnlHeader = new Panel();
            this.lblAppName = new Label();
            this.lblWelcome = new Label();
            this.lblSignedInAs = new Label();
            this.btnLogout = new Button();
            this.pnlContent = new Panel();
            this.lblSectionTitle = new Label();
            this.lblGridNote = new Label();
            this.lblUserCount = new Label();
            this.btnRefresh = new Button();
            this.dgvUsers = new DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblAppName);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblSignedInAs);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(960, 136);
            this.pnlHeader.TabIndex = 0;
            //
            // lblAppName
            //
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.lblAppName.ForeColor = Color.FromArgb(147, 197, 253);
            this.lblAppName.Location = new Point(45, 21);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new Size(193, 17);
            this.lblAppName.Text = "ACCOUNT MANAGEMENT PORTAL";
            //
            // lblWelcome
            //
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(40, 44);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(232, 45);
            this.lblWelcome.Text = "Welcome, User";
            //
            // lblSignedInAs
            //
            this.lblSignedInAs.AutoSize = true;
            this.lblSignedInAs.Font = new Font("Segoe UI", 9.5F);
            this.lblSignedInAs.ForeColor = Color.FromArgb(203, 213, 225);
            this.lblSignedInAs.Location = new Point(45, 94);
            this.lblSignedInAs.Name = "lblSignedInAs";
            this.lblSignedInAs.Size = new Size(118, 17);
            this.lblSignedInAs.Text = "Signed in as @user";
            //
            // btnLogout
            //
            this.btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLogout.BackColor = Color.FromArgb(239, 68, 68);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(792, 48);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(122, 42);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // pnlContent
            //
            this.pnlContent.BackColor = Color.White;
            this.pnlContent.Controls.Add(this.lblSectionTitle);
            this.pnlContent.Controls.Add(this.lblGridNote);
            this.pnlContent.Controls.Add(this.lblUserCount);
            this.pnlContent.Controls.Add(this.btnRefresh);
            this.pnlContent.Controls.Add(this.dgvUsers);
            this.pnlContent.Location = new Point(40, 169);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new Size(874, 448);
            this.pnlContent.TabIndex = 1;
            //
            // lblSectionTitle
            //
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            this.lblSectionTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblSectionTitle.Location = new Point(25, 19);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new Size(197, 32);
            this.lblSectionTitle.Text = "Registered users";
            //
            // lblGridNote
            //
            this.lblGridNote.AutoSize = true;
            this.lblGridNote.Font = new Font("Segoe UI", 9.5F);
            this.lblGridNote.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblGridNote.Location = new Point(28, 55);
            this.lblGridNote.Name = "lblGridNote";
            this.lblGridNote.Size = new Size(319, 17);
            this.lblGridNote.Text = "Passwords and password hashes are intentionally hidden.";
            //
            // lblUserCount
            //
            this.lblUserCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblUserCount.Font = new Font("Segoe UI", 9F);
            this.lblUserCount.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblUserCount.Location = new Point(566, 60);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new Size(150, 20);
            this.lblUserCount.Text = "0 registered users";
            this.lblUserCount.TextAlign = ContentAlignment.MiddleRight;
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(727, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(118, 38);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh grid";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // dgvUsers
            //
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.BorderStyle = BorderStyle.None;
            this.dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(241, 245, 249);
            headerStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(51, 65, 85);
            headerStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            headerStyle.SelectionForeColor = Color.FromArgb(51, 65, 85);
            headerStyle.WrapMode = DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvUsers.ColumnHeadersHeight = 38;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = Color.FromArgb(226, 232, 240);
            this.dgvUsers.Location = new Point(29, 93);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            rowStyle.BackColor = Color.White;
            rowStyle.Font = new Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = Color.FromArgb(51, 65, 85);
            rowStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            rowStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            this.dgvUsers.RowsDefaultCellStyle = rowStyle;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 34;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new Size(816, 326);
            this.dgvUsers.TabIndex = 1;
            //
            // HomeForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.ClientSize = new Size(960, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Home - 24-58158-2 Login System";
            this.FormClosing += new FormClosingEventHandler(this.HomeForm_FormClosing);
            this.Shown += new System.EventHandler(this.HomeForm_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
