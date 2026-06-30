namespace DentalSystem
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlLeftBranding = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblClinicTitle = new System.Windows.Forms.Label();
            this.lblClinicSub = new System.Windows.Forms.Label();
            this.lblBrandingText = new System.Windows.Forms.Label();
            this.pnlRightForm = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSignInTitle = new System.Windows.Forms.Label();
            this.lblSignInSub = new System.Windows.Forms.Label();
            this.lblUserTag = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassTag = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRoleTag = new System.Windows.Forms.Label();
            this.pnlRoleContainer = new System.Windows.Forms.Panel();
            this.rbadmin = new System.Windows.Forms.RadioButton();
            this.rbdoctor = new System.Windows.Forms.RadioButton();
            this.rbrec = new System.Windows.Forms.RadioButton();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlLeftBranding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlRightForm.SuspendLayout();
            this.pnlRoleContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlLeftBranding
            // 
            this.pnlLeftBranding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.pnlLeftBranding.Controls.Add(this.pictureBox1);
            this.pnlLeftBranding.Controls.Add(this.lblClinicTitle);
            this.pnlLeftBranding.Controls.Add(this.lblClinicSub);
            this.pnlLeftBranding.Controls.Add(this.lblBrandingText);
            this.pnlLeftBranding.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftBranding.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftBranding.Name = "pnlLeftBranding";
            this.pnlLeftBranding.Size = new System.Drawing.Size(350, 500);
            this.pnlLeftBranding.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DentalSystem.Properties.Resources.goos;
            this.pictureBox1.Location = new System.Drawing.Point(125, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblClinicTitle
            // 
            this.lblClinicTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblClinicTitle.ForeColor = System.Drawing.Color.White;
            this.lblClinicTitle.Location = new System.Drawing.Point(20, 200);
            this.lblClinicTitle.Name = "lblClinicTitle";
            this.lblClinicTitle.Size = new System.Drawing.Size(310, 50);
            this.lblClinicTitle.TabIndex = 1;
            this.lblClinicTitle.Text = "SmileCare";
            this.lblClinicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClinicSub
            // 
            this.lblClinicSub.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblClinicSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.lblClinicSub.Location = new System.Drawing.Point(20, 250);
            this.lblClinicSub.Name = "lblClinicSub";
            this.lblClinicSub.Size = new System.Drawing.Size(310, 30);
            this.lblClinicSub.TabIndex = 2;
            this.lblClinicSub.Text = "Dental Clinic System";
            this.lblClinicSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandingText
            // 
            this.lblBrandingText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblBrandingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(170)))), ((int)(((byte)(190)))));
            this.lblBrandingText.Location = new System.Drawing.Point(30, 360);
            this.lblBrandingText.Name = "lblBrandingText";
            this.lblBrandingText.Size = new System.Drawing.Size(290, 80);
            this.lblBrandingText.TabIndex = 3;
            this.lblBrandingText.Text = "Providing state-of-the-art management tools for professional dental clinics and healthcare providers.";
            this.lblBrandingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRightForm
            // 
            this.pnlRightForm.BackColor = System.Drawing.Color.White;
            this.pnlRightForm.Controls.Add(this.btnClose);
            this.pnlRightForm.Controls.Add(this.lblSignInTitle);
            this.pnlRightForm.Controls.Add(this.lblSignInSub);
            this.pnlRightForm.Controls.Add(this.lblUserTag);
            this.pnlRightForm.Controls.Add(this.txtUsername);
            this.pnlRightForm.Controls.Add(this.lblPassTag);
            this.pnlRightForm.Controls.Add(this.txtPassword);
            this.pnlRightForm.Controls.Add(this.lblRoleTag);
            this.pnlRightForm.Controls.Add(this.pnlRoleContainer);
            this.pnlRightForm.Controls.Add(this.btnLogin);
            this.pnlRightForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightForm.Location = new System.Drawing.Point(350, 0);
            this.pnlRightForm.Name = "pnlRightForm";
            this.pnlRightForm.Size = new System.Drawing.Size(500, 500);
            this.pnlRightForm.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnClose.Location = new System.Drawing.Point(455, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 33);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler((s, e) => System.Windows.Forms.Application.Exit());
            // 
            // lblSignInTitle
            // 
            this.lblSignInTitle.AutoSize = true;
            this.lblSignInTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSignInTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblSignInTitle.Location = new System.Drawing.Point(44, 45);
            this.lblSignInTitle.Name = "lblSignInTitle";
            this.lblSignInTitle.Size = new System.Drawing.Size(155, 54);
            this.lblSignInTitle.TabIndex = 0;
            this.lblSignInTitle.Text = "Sign In";
            // 
            // lblSignInSub
            // 
            this.lblSignInSub.AutoSize = true;
            this.lblSignInSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSignInSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSignInSub.Location = new System.Drawing.Point(49, 100);
            this.lblSignInSub.Name = "lblSignInSub";
            this.lblSignInSub.Size = new System.Drawing.Size(306, 25);
            this.lblSignInSub.TabIndex = 1;
            this.lblSignInSub.Text = "Enter your credentials to continue.";
            // 
            // lblUserTag
            // 
            this.lblUserTag.AutoSize = true;
            this.lblUserTag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblUserTag.Location = new System.Drawing.Point(49, 145);
            this.lblUserTag.Name = "lblUserTag";
            this.lblUserTag.Size = new System.Drawing.Size(102, 25);
            this.lblUserTag.TabIndex = 2;
            this.lblUserTag.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(53, 172);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(395, 37);
            this.txtUsername.TabIndex = 3;
            // 
            // lblPassTag
            // 
            this.lblPassTag.AutoSize = true;
            this.lblPassTag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblPassTag.Location = new System.Drawing.Point(49, 222);
            this.lblPassTag.Name = "lblPassTag";
            this.lblPassTag.Size = new System.Drawing.Size(97, 25);
            this.lblPassTag.TabIndex = 4;
            this.lblPassTag.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(53, 249);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(395, 37);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRoleTag
            // 
            this.lblRoleTag.AutoSize = true;
            this.lblRoleTag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblRoleTag.Location = new System.Drawing.Point(49, 302);
            this.lblRoleTag.Name = "lblRoleTag";
            this.lblRoleTag.Size = new System.Drawing.Size(120, 25);
            this.lblRoleTag.TabIndex = 6;
            this.lblRoleTag.Text = "Select Role:";
            // 
            // pnlRoleContainer
            // 
            this.pnlRoleContainer.Controls.Add(this.rbadmin);
            this.pnlRoleContainer.Controls.Add(this.rbdoctor);
            this.pnlRoleContainer.Controls.Add(this.rbrec);
            this.pnlRoleContainer.Location = new System.Drawing.Point(53, 327);
            this.pnlRoleContainer.Name = "pnlRoleContainer";
            this.pnlRoleContainer.Size = new System.Drawing.Size(395, 45);
            this.pnlRoleContainer.TabIndex = 7;
            // 
            // rbadmin
            // 
            this.rbadmin.AutoSize = true;
            this.rbadmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbadmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.rbadmin.Location = new System.Drawing.Point(10, 8);
            this.rbadmin.Name = "rbadmin";
            this.rbadmin.Size = new System.Drawing.Size(95, 30);
            this.rbadmin.TabIndex = 0;
            this.rbadmin.TabStop = true;
            this.rbadmin.Text = "Admin";
            this.rbadmin.UseVisualStyleBackColor = true;
            // 
            // rbdoctor
            // 
            this.rbdoctor.AutoSize = true;
            this.rbdoctor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbdoctor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.rbdoctor.Location = new System.Drawing.Point(135, 8);
            this.rbdoctor.Name = "rbdoctor";
            this.rbdoctor.Size = new System.Drawing.Size(99, 30);
            this.rbdoctor.TabIndex = 1;
            this.rbdoctor.TabStop = true;
            this.rbdoctor.Text = "Doctor";
            this.rbdoctor.UseVisualStyleBackColor = true;
            // 
            // rbrec
            // 
            this.rbrec.AutoSize = true;
            this.rbrec.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbrec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.rbrec.Location = new System.Drawing.Point(260, 8);
            this.rbrec.Name = "rbrec";
            this.rbrec.Size = new System.Drawing.Size(127, 30);
            this.rbrec.TabIndex = 2;
            this.rbrec.TabStop = true;
            this.rbrec.Text = "Reception";
            this.rbrec.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(53, 395);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(395, 45);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.pnlRightForm);
            this.Controls.Add(this.pnlLeftBranding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmileCare Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.pnlLeftBranding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlRightForm.ResumeLayout(false);
            this.pnlRightForm.PerformLayout();
            this.pnlRoleContainer.ResumeLayout(false);
            this.pnlRoleContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel pnlLeftBranding;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblClinicTitle;
        private System.Windows.Forms.Label lblClinicSub;
        private System.Windows.Forms.Label lblBrandingText;
        private System.Windows.Forms.Panel pnlRightForm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSignInTitle;
        private System.Windows.Forms.Label lblSignInSub;
        private System.Windows.Forms.Label lblUserTag;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassTag;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRoleTag;
        private System.Windows.Forms.Panel pnlRoleContainer;
        private System.Windows.Forms.RadioButton rbadmin;
        private System.Windows.Forms.RadioButton rbdoctor;
        private System.Windows.Forms.RadioButton rbrec;
        private System.Windows.Forms.Button btnLogin;
    }
}
