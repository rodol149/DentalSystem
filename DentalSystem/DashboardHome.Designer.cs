namespace DentalSystem
{
    partial class DashboardHome
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlPatients = new System.Windows.Forms.Panel();
            this.pnlDoctors = new System.Windows.Forms.Panel();
            this.pnlReception = new System.Windows.Forms.Panel();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.pnlTreatments = new System.Windows.Forms.Panel();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.pnlBilling = new System.Windows.Forms.Panel();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblPatCount = new System.Windows.Forms.Label();
            this.lblDocCount = new System.Windows.Forms.Label();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblApptCount = new System.Windows.Forms.Label();
            this.lblTreatCount = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblPendingInv = new System.Windows.Forms.Label();
            this.lblUnpaidInv = new System.Windows.Forms.Label();
            this.lblPatTitle = new System.Windows.Forms.Label();
            this.lblDocTitle = new System.Windows.Forms.Label();
            this.lblRecTitle = new System.Windows.Forms.Label();
            this.lblApptTitle = new System.Windows.Forms.Label();
            this.lblTreatTitle = new System.Windows.Forms.Label();
            this.lblRevTitle = new System.Windows.Forms.Label();
            this.lblPendTitle = new System.Windows.Forms.Label();
            this.lblUnpTitle = new System.Windows.Forms.Label();
            this.lblPatIcon = new System.Windows.Forms.Label();
            this.lblDocIcon = new System.Windows.Forms.Label();
            this.lblRecIcon = new System.Windows.Forms.Label();
            this.lblApptIcon = new System.Windows.Forms.Label();
            this.lblTreatIcon = new System.Windows.Forms.Label();
            this.lblRevIcon = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            this.SuspendLayout();
            // 
            // colours
            // 
            var navyBlue = System.Drawing.Color.FromArgb(30, 58, 95);
            var accentBlue = System.Drawing.Color.FromArgb(41, 128, 185);
            var tealGreen = System.Drawing.Color.FromArgb(22, 160, 133);
            var orange = System.Drawing.Color.FromArgb(211, 84, 0);
            var purple = System.Drawing.Color.FromArgb(142, 68, 173);
            var emerald = System.Drawing.Color.FromArgb(39, 174, 96);
            var deepBlue = System.Drawing.Color.FromArgb(52, 73, 94);
            var lightBg = System.Drawing.Color.FromArgb(245, 247, 250);
            var textDark = System.Drawing.Color.FromArgb(44, 62, 80);
            var white = System.Drawing.Color.White;
            // 
            // DashboardHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = lightBg;
            this.ClientSize = new System.Drawing.Size(1218, 637);
            this.Name = "DashboardHome";
            this.Text = "Dashboard Home";
            this.Load += new System.EventHandler(this.DashboardHome_Load);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = textDark;
            this.lblWelcome.Location = new System.Drawing.Point(24, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(700, 40);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back, " + DentalSystem.CurrentUser.full_name + "!";
            this.Controls.Add(this.lblWelcome);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblSubTitle.Location = new System.Drawing.Point(26, 58);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(500, 22);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Here\'s what\'s happening at your clinic today.";
            this.Controls.Add(this.lblSubTitle);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblDate.Location = new System.Drawing.Point(800, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(280, 28);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = System.DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Controls.Add(this.lblDate);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = accentBlue;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = white;
            this.btnRefresh.Location = new System.Drawing.Point(1090, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "⟳  Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.Controls.Add(this.btnRefresh);
            // 
            // Card 1 – Patients (blue)
            // 
            BuildStatCard(this.pnlPatients,
                          this.lblPatIcon, "👤",
                          this.lblPatTitle, "Total Patients",
                          this.lblPatCount,
                          accentBlue,
                          new System.Drawing.Point(24, 90),
                          "All time");
            // 
            // Card 2 – Doctors (teal)
            // 
            BuildStatCard(this.pnlDoctors,
                          this.lblDocIcon, "🩺",
                          this.lblDocTitle, "Active Doctors",
                          this.lblDocCount,
                          tealGreen,
                          new System.Drawing.Point(215, 90),
                          "Active");
            // 
            // Card 3 - Receptionists (purple)
            // 
            BuildStatCard(this.pnlReception,
                          this.lblRecIcon, "👥",
                          this.lblRecTitle, "Reception Staff",
                          this.lblRecCount,
                          purple,
                          new System.Drawing.Point(406, 90),
                          "Active");
            // 
            // Card 4 – Appointments today (orange)
            // 
            BuildStatCard(this.pnlAppointments,
                          this.lblApptIcon, "📅",
                          this.lblApptTitle, "Today's Appointment",
                          this.lblApptCount,
                          orange,
                          new System.Drawing.Point(597, 90),
                          "Today");
            // 
            // Card 5 – Treatments (deepBlue)
            // 
            BuildStatCard(this.pnlTreatments,
                          this.lblTreatIcon, "💊",
                          this.lblTreatTitle, "Total Treatments",
                          this.lblTreatCount,
                          deepBlue,
                          new System.Drawing.Point(788, 90),
                          "All time");
            // 
            // Card 6 – Revenue (emerald)
            // 
            BuildStatCard(this.pnlRevenue,
                          this.lblRevIcon, "💰",
                          this.lblRevTitle, "Revenue Collected",
                          this.lblRevenue,
                          emerald,
                          new System.Drawing.Point(979, 90),
                          "Payments received");
            // 
            // pnlBilling
            // 
            this.pnlBilling.BackColor = white;
            this.pnlBilling.Location = new System.Drawing.Point(24, 268);
            this.pnlBilling.Name = "pnlBilling";
            this.pnlBilling.Size = new System.Drawing.Size(370, 140);
            this.pnlBilling.TabIndex = 4;
            this.Controls.Add(this.pnlBilling);
            // 
            // lblBillTitle
            // 
            var lblBillTitle = new System.Windows.Forms.Label();
            lblBillTitle.AutoSize = true;
            lblBillTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblBillTitle.ForeColor = textDark;
            lblBillTitle.Location = new System.Drawing.Point(16, 14);
            lblBillTitle.Name = "lblBillTitle";
            lblBillTitle.Size = new System.Drawing.Size(200, 32);
            lblBillTitle.Text = "Billing Overview";
            this.pnlBilling.Controls.Add(lblBillTitle);
            // 
            // pnlPend
            // 
            var pnlPend = new System.Windows.Forms.Panel();
            pnlPend.BackColor = System.Drawing.Color.FromArgb(253, 245, 230);
            pnlPend.Location = new System.Drawing.Point(14, 50);
            pnlPend.Size = new System.Drawing.Size(155, 72);
            this.pnlBilling.Controls.Add(pnlPend);
            // 
            // lblPendTitle
            // 
            this.lblPendTitle.AutoSize = true;
            this.lblPendTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPendTitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblPendTitle.Location = new System.Drawing.Point(8, 8);
            this.lblPendTitle.Name = "lblPendTitle";
            this.lblPendTitle.Size = new System.Drawing.Size(130, 21);
            this.lblPendTitle.Text = "Pending Invoices";
            pnlPend.Controls.Add(this.lblPendTitle);
            // 
            // lblPendingInv
            // 
            this.lblPendingInv.AutoSize = true;
            this.lblPendingInv.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPendingInv.ForeColor = orange;
            this.lblPendingInv.Location = new System.Drawing.Point(8, 26);
            this.lblPendingInv.Name = "lblPendingInv";
            this.lblPendingInv.Size = new System.Drawing.Size(43, 60);
            this.lblPendingInv.Text = "…";
            pnlPend.Controls.Add(this.lblPendingInv);
            // 
            // pnlUnp
            // 
            var pnlUnp = new System.Windows.Forms.Panel();
            pnlUnp.BackColor = System.Drawing.Color.FromArgb(250, 235, 235);
            pnlUnp.Location = new System.Drawing.Point(185, 50);
            pnlUnp.Size = new System.Drawing.Size(155, 72);
            this.pnlBilling.Controls.Add(pnlUnp);
            // 
            // lblUnpTitle
            // 
            this.lblUnpTitle.AutoSize = true;
            this.lblUnpTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUnpTitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblUnpTitle.Location = new System.Drawing.Point(8, 8);
            this.lblUnpTitle.Name = "lblUnpTitle";
            this.lblUnpTitle.Size = new System.Drawing.Size(125, 21);
            this.lblUnpTitle.Text = "Unpaid Invoices";
            pnlUnp.Controls.Add(this.lblUnpTitle);
            // 
            // lblUnpaidInv
            // 
            this.lblUnpaidInv.AutoSize = true;
            this.lblUnpaidInv.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblUnpaidInv.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblUnpaidInv.Location = new System.Drawing.Point(8, 26);
            this.lblUnpaidInv.Name = "lblUnpaidInv";
            this.lblUnpaidInv.Size = new System.Drawing.Size(43, 60);
            this.lblUnpaidInv.Text = "…";
            pnlUnp.Controls.Add(this.lblUnpaidInv);
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = textDark;
            this.lblRecentTitle.Location = new System.Drawing.Point(410, 270);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(252, 32);
            this.lblRecentTitle.Text = "Recent Appointments";
            this.Controls.Add(this.lblRecentTitle);
            // 
            // dgvRecent
            // 
            this.dgvRecent.AllowUserToAddRows = false;
            this.dgvRecent.AllowUserToDeleteRows = false;
            this.dgvRecent.ReadOnly = true;
            this.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecent.BackgroundColor = white;
            this.dgvRecent.RowHeadersVisible = false;
            this.dgvRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecent.Location = new System.Drawing.Point(410, 300);
            this.dgvRecent.Size = new System.Drawing.Size(780, 315);
            this.dgvRecent.TabIndex = 5;
            this.dgvRecent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRecent.EnableHeadersVisualStyles = false;
            // 
            // ColumnHeadersDefaultCellStyle
            // 
            this.dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = navyBlue;
            this.dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = white;
            this.dgvRecent.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvRecent.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            // 
            // AlternatingRowsDefaultCellStyle
            // 
            this.dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.dgvRecent.DefaultCellStyle.SelectionBackColor = accentBlue;
            this.dgvRecent.DefaultCellStyle.SelectionForeColor = white;
            this.dgvRecent.RowTemplate.Height = 32;
            this.Controls.Add(this.dgvRecent);
            // 
            // pnlQuick
            // 
            var pnlQuick = new System.Windows.Forms.Panel();
            pnlQuick.BackColor = white;
            pnlQuick.Location = new System.Drawing.Point(24, 426);
            pnlQuick.Size = new System.Drawing.Size(370, 190);
            this.Controls.Add(pnlQuick);
            // 
            // lblQuick
            // 
            var lblQuick = new System.Windows.Forms.Label();
            lblQuick.AutoSize = true;
            lblQuick.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblQuick.ForeColor = textDark;
            lblQuick.Location = new System.Drawing.Point(16, 14);
            lblQuick.Name = "lblQuick";
            lblQuick.Size = new System.Drawing.Size(167, 32);
            lblQuick.Text = "Quick Actions";
            pnlQuick.Controls.Add(lblQuick);
            // 
            // Quick action buttons
            // 
            string[] quickLabels = { "New Patient", "Book Appointment", "Add Treatment", "Record Payment" };
            System.Drawing.Color[] quickColors = { accentBlue, tealGreen, orange, purple };
            for (int i = 0; i < quickLabels.Length; i++)
            {
                var qBtn = new System.Windows.Forms.Button();
                qBtn.Text = quickLabels[i];
                qBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                qBtn.BackColor = quickColors[i];
                qBtn.ForeColor = white;
                qBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                qBtn.FlatAppearance.BorderSize = 0;
                qBtn.Size = new System.Drawing.Size(162, 38);
                qBtn.Location = new System.Drawing.Point(14 + (i % 2) * 178, 50 + (i / 2) * 50);
                qBtn.Cursor = System.Windows.Forms.Cursors.Hand;
                qBtn.Click += new System.EventHandler(this.QuickAction_Click);
                pnlQuick.Controls.Add(qBtn);
            }

            this.ResumeLayout(false);
        }

        #endregion

        private void BuildStatCard(System.Windows.Forms.Panel pnl,
                                   System.Windows.Forms.Label iconLbl, string icon,
                                   System.Windows.Forms.Label titleLbl, string title,
                                   System.Windows.Forms.Label countLbl,
                                   System.Drawing.Color color,
                                   System.Drawing.Point location,
                                   string subtext)
        {
            int w = 175, h = 165;
            pnl.BackColor = color;
            pnl.Location = location;
            pnl.Size = new System.Drawing.Size(w, h);
            pnl.TabIndex = 10;
            pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.StatPanel_Paint);

            iconLbl.Text = icon;
            iconLbl.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            iconLbl.ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);
            iconLbl.Location = new System.Drawing.Point(w - 65, 10);
            iconLbl.AutoSize = true;
            pnl.Controls.Add(iconLbl);

            titleLbl.Text = title;
            titleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            titleLbl.ForeColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
            titleLbl.Location = new System.Drawing.Point(14, 14);
            titleLbl.AutoSize = false;
            titleLbl.Size = new System.Drawing.Size(w - 20, 20);
            pnl.Controls.Add(titleLbl);

            countLbl.Text = "—";
            countLbl.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            countLbl.ForeColor = System.Drawing.Color.White;
            countLbl.Location = new System.Drawing.Point(10, 48);
            countLbl.AutoSize = false;
            countLbl.Size = new System.Drawing.Size(w - 15, 68);
            pnl.Controls.Add(countLbl);

            var lblSub = new System.Windows.Forms.Label();
            lblSub.Text = subtext;
            lblSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblSub.ForeColor = System.Drawing.Color.FromArgb(180, 255, 255, 255);
            lblSub.Location = new System.Drawing.Point(14, 126);
            lblSub.AutoSize = true;
            pnl.Controls.Add(lblSub);

            this.Controls.Add(pnl);
        }

        // ── Controls ─────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlPatients;
        private System.Windows.Forms.Panel pnlDoctors;
        private System.Windows.Forms.Panel pnlReception;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Panel pnlTreatments;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Panel pnlBilling;

        private System.Windows.Forms.Label lblPatCount;
        private System.Windows.Forms.Label lblDocCount;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblApptCount;
        private System.Windows.Forms.Label lblTreatCount;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblPendingInv;
        private System.Windows.Forms.Label lblUnpaidInv;

        private System.Windows.Forms.Label lblPatTitle;
        private System.Windows.Forms.Label lblDocTitle;
        private System.Windows.Forms.Label lblRecTitle;
        private System.Windows.Forms.Label lblApptTitle;
        private System.Windows.Forms.Label lblTreatTitle;
        private System.Windows.Forms.Label lblRevTitle;
        private System.Windows.Forms.Label lblPendTitle;
        private System.Windows.Forms.Label lblUnpTitle;

        private System.Windows.Forms.Label lblPatIcon;
        private System.Windows.Forms.Label lblDocIcon;
        private System.Windows.Forms.Label lblRecIcon;
        private System.Windows.Forms.Label lblApptIcon;
        private System.Windows.Forms.Label lblTreatIcon;
        private System.Windows.Forms.Label lblRevIcon;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRecentTitle;

        private System.Windows.Forms.DataGridView dgvRecent;
        private System.Windows.Forms.Button btnRefresh;
    }
}
