namespace DentalSystem
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnservice = new System.Windows.Forms.Button();
            this.btntre = new System.Windows.Forms.Button();
            this.btnpay = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnreports = new System.Windows.Forms.Button();
            this.btndoc = new System.Windows.Forms.Button();
            this.btnappo = new System.Windows.Forms.Button();
            this.btnpat = new System.Windows.Forms.Button();
            this.btndash = new System.Windows.Forms.Button();
            this.btnuser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 51);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(472, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.btnuser);
            this.panel2.Controls.Add(this.btnservice);
            this.panel2.Controls.Add(this.btntre);
            this.panel2.Controls.Add(this.btnpay);
            this.panel2.Controls.Add(this.btnlogout);
            this.panel2.Controls.Add(this.btnreports);
            this.panel2.Controls.Add(this.btndoc);
            this.panel2.Controls.Add(this.btnappo);
            this.panel2.Controls.Add(this.btnpat);
            this.panel2.Controls.Add(this.btndash);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 637);
            this.panel2.TabIndex = 1;
            // 
            // btnservice
            // 
            this.btnservice.FlatAppearance.BorderSize = 0;
            this.btnservice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnservice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnservice.ForeColor = System.Drawing.Color.White;
            this.btnservice.Location = new System.Drawing.Point(12, 367);
            this.btnservice.Name = "btnservice";
            this.btnservice.Size = new System.Drawing.Size(200, 52);
            this.btnservice.TabIndex = 7;
            this.btnservice.Text = "Service";
            this.btnservice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnservice.UseVisualStyleBackColor = true;
            this.btnservice.Click += new System.EventHandler(this.btnservice_Click);
            // 
            // btntre
            // 
            this.btntre.FlatAppearance.BorderSize = 0;
            this.btntre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btntre.ForeColor = System.Drawing.Color.White;
            this.btntre.Location = new System.Drawing.Point(12, 247);
            this.btntre.Name = "btntre";
            this.btntre.Size = new System.Drawing.Size(200, 50);
            this.btntre.TabIndex = 3;
            this.btntre.Text = "Treatments";
            this.btntre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntre.UseVisualStyleBackColor = true;
            this.btntre.Click += new System.EventHandler(this.btntre_Click);
            // 
            // btnpay
            // 
            this.btnpay.FlatAppearance.BorderSize = 0;
            this.btnpay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnpay.ForeColor = System.Drawing.Color.White;
            this.btnpay.Location = new System.Drawing.Point(12, 303);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(200, 46);
            this.btnpay.TabIndex = 4;
            this.btnpay.Text = "Payments";
            this.btnpay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpay.UseVisualStyleBackColor = true;
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // btnlogout
            // 
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Location = new System.Drawing.Point(12, 522);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(200, 43);
            this.btnlogout.TabIndex = 5;
            this.btnlogout.Text = "Logout";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btnreports
            // 
            this.btnreports.FlatAppearance.BorderSize = 0;
            this.btnreports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnreports.ForeColor = System.Drawing.Color.White;
            this.btnreports.Location = new System.Drawing.Point(12, 425);
            this.btnreports.Name = "btnreports";
            this.btnreports.Size = new System.Drawing.Size(200, 34);
            this.btnreports.TabIndex = 6;
            this.btnreports.Text = "Reports";
            this.btnreports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreports.UseVisualStyleBackColor = true;
            this.btnreports.Click += new System.EventHandler(this.btnreports_Click);
            // 
            // btndoc
            // 
            this.btndoc.FlatAppearance.BorderSize = 0;
            this.btndoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btndoc.ForeColor = System.Drawing.Color.White;
            this.btndoc.Location = new System.Drawing.Point(12, 136);
            this.btndoc.Name = "btndoc";
            this.btndoc.Size = new System.Drawing.Size(200, 34);
            this.btndoc.TabIndex = 4;
            this.btndoc.Text = "Doctors";
            this.btndoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndoc.UseVisualStyleBackColor = true;
            this.btndoc.Click += new System.EventHandler(this.btndoc_Click);
            // 
            // btnappo
            // 
            this.btnappo.FlatAppearance.BorderSize = 0;
            this.btnappo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnappo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnappo.ForeColor = System.Drawing.Color.White;
            this.btnappo.Location = new System.Drawing.Point(12, 176);
            this.btnappo.Name = "btnappo";
            this.btnappo.Size = new System.Drawing.Size(200, 52);
            this.btnappo.TabIndex = 5;
            this.btnappo.Text = "Appointments";
            this.btnappo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnappo.UseVisualStyleBackColor = true;
            this.btnappo.Click += new System.EventHandler(this.btnappo_Click);
            // 
            // btnpat
            // 
            this.btnpat.FlatAppearance.BorderSize = 0;
            this.btnpat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnpat.ForeColor = System.Drawing.Color.White;
            this.btnpat.Location = new System.Drawing.Point(12, 74);
            this.btnpat.Name = "btnpat";
            this.btnpat.Size = new System.Drawing.Size(200, 45);
            this.btnpat.TabIndex = 3;
            this.btnpat.Text = "Patients";
            this.btnpat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpat.UseVisualStyleBackColor = true;
            this.btnpat.Click += new System.EventHandler(this.btnpat_Click);
            // 
            // btndash
            // 
            this.btndash.FlatAppearance.BorderSize = 0;
            this.btndash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndash.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btndash.ForeColor = System.Drawing.Color.White;
            this.btndash.Location = new System.Drawing.Point(12, 16);
            this.btndash.Name = "btndash";
            this.btndash.Size = new System.Drawing.Size(200, 52);
            this.btndash.TabIndex = 2;
            this.btndash.Text = "Dashboard";
            this.btndash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndash.UseVisualStyleBackColor = true;
            // 
            // btnuser
            // 
            this.btnuser.FlatAppearance.BorderSize = 0;
            this.btnuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnuser.ForeColor = System.Drawing.Color.White;
            this.btnuser.Location = new System.Drawing.Point(12, 482);
            this.btnuser.Name = "btnuser";
            this.btnuser.Size = new System.Drawing.Size(200, 34);
            this.btnuser.TabIndex = 8;
            this.btnuser.Text = "User";
            this.btnuser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuser.UseVisualStyleBackColor = true;
            this.btnuser.Click += new System.EventHandler(this.btnuser_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(222, 51);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1218, 637);
            this.panelMain.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 688);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btndoc;
        private System.Windows.Forms.Button btnappo;
        private System.Windows.Forms.Button btnpat;
        private System.Windows.Forms.Button btndash;
        private System.Windows.Forms.Button btntre;
        private System.Windows.Forms.Button btnpay;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnreports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnservice;
        private System.Windows.Forms.Button btnuser;
        private System.Windows.Forms.Panel panelMain;
    }
}