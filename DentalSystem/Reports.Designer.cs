namespace DentalSystem
{
    partial class Reports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.datefrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateto = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnviewreport = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlTotalInvoices = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pa = new System.Windows.Forms.Label();
            this.pnlTotalAmount = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbtotalamount = new System.Windows.Forms.Label();
            this.pnlPaid = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pid = new System.Windows.Forms.Label();
            this.pnlUnpaid = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pnlTopBar.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlTotalInvoices.SuspendLayout();
            this.pnlTotalAmount.SuspendLayout();
            this.pnlPaid.SuspendLayout();
            this.pnlUnpaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.label5);
            this.pnlTopBar.Controls.Add(this.datefrom);
            this.pnlTopBar.Controls.Add(this.label3);
            this.pnlTopBar.Controls.Add(this.dateto);
            this.pnlTopBar.Controls.Add(this.label8);
            this.pnlTopBar.Controls.Add(this.txtsearch);
            this.pnlTopBar.Controls.Add(this.btnviewreport);
            this.pnlTopBar.Controls.Add(this.btnrefresh);
            this.pnlTopBar.Controls.Add(this.btnprint);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1218, 110);
            this.pnlTopBar.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "From Date:";
            // 
            // datefrom
            // 
            this.datefrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.datefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datefrom.Location = new System.Drawing.Point(20, 34);
            this.datefrom.Name = "datefrom";
            this.datefrom.Size = new System.Drawing.Size(200, 34);
            this.datefrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label3.Location = new System.Drawing.Point(236, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "To Date:";
            // 
            // dateto
            // 
            this.dateto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateto.Location = new System.Drawing.Point(240, 34);
            this.dateto.Name = "dateto";
            this.dateto.Size = new System.Drawing.Size(200, 34);
            this.dateto.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label8.Location = new System.Drawing.Point(456, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Search:";
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtsearch.Location = new System.Drawing.Point(460, 34);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(260, 34);
            this.txtsearch.TabIndex = 5;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnviewreport
            // 
            this.btnviewreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnviewreport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnviewreport.FlatAppearance.BorderSize = 0;
            this.btnviewreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewreport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnviewreport.ForeColor = System.Drawing.Color.White;
            this.btnviewreport.Location = new System.Drawing.Point(740, 30);
            this.btnviewreport.Name = "btnviewreport";
            this.btnviewreport.Size = new System.Drawing.Size(140, 42);
            this.btnviewreport.TabIndex = 6;
            this.btnviewreport.Text = "View Report";
            this.btnviewreport.UseVisualStyleBackColor = false;
            this.btnviewreport.Click += new System.EventHandler(this.btnviewreport_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.FlatAppearance.BorderSize = 0;
            this.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnrefresh.ForeColor = System.Drawing.Color.White;
            this.btnrefresh.Location = new System.Drawing.Point(890, 30);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(140, 42);
            this.btnrefresh.TabIndex = 7;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = false;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(1040, 30);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(140, 42);
            this.btnprint.TabIndex = 8;
            this.btnprint.Text = "Print Page";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlStats.Controls.Add(this.pnlTotalInvoices);
            this.pnlStats.Controls.Add(this.pnlTotalAmount);
            this.pnlStats.Controls.Add(this.pnlPaid);
            this.pnlStats.Controls.Add(this.pnlUnpaid);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 110);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlStats.Size = new System.Drawing.Size(1218, 110);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlTotalInvoices
            // 
            this.pnlTotalInvoices.BackColor = System.Drawing.Color.White;
            this.pnlTotalInvoices.Controls.Add(this.label2);
            this.pnlTotalInvoices.Controls.Add(this.pa);
            this.pnlTotalInvoices.Location = new System.Drawing.Point(20, 12);
            this.pnlTotalInvoices.Name = "pnlTotalInvoices";
            this.pnlTotalInvoices.Size = new System.Drawing.Size(265, 85);
            this.pnlTotalInvoices.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Invoices";
            // 
            // pa
            // 
            this.pa.AutoSize = true;
            this.pa.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.pa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.pa.Location = new System.Drawing.Point(10, 32);
            this.pa.Name = "pa";
            this.pa.Size = new System.Drawing.Size(46, 54);
            this.pa.TabIndex = 1;
            this.pa.Text = "0";
            // 
            // pnlTotalAmount
            // 
            this.pnlTotalAmount.BackColor = System.Drawing.Color.White;
            this.pnlTotalAmount.Controls.Add(this.label4);
            this.pnlTotalAmount.Controls.Add(this.lbtotalamount);
            this.pnlTotalAmount.Location = new System.Drawing.Point(315, 12);
            this.pnlTotalAmount.Name = "pnlTotalAmount";
            this.pnlTotalAmount.Size = new System.Drawing.Size(265, 85);
            this.pnlTotalAmount.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(14, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Amount";
            // 
            // lbtotalamount
            // 
            this.lbtotalamount.AutoSize = true;
            this.lbtotalamount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbtotalamount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.lbtotalamount.Location = new System.Drawing.Point(10, 32);
            this.lbtotalamount.Name = "lbtotalamount";
            this.lbtotalamount.Size = new System.Drawing.Size(107, 54);
            this.lbtotalamount.TabIndex = 1;
            this.lbtotalamount.Text = "$0.0";
            // 
            // pnlPaid
            // 
            this.pnlPaid.BackColor = System.Drawing.Color.White;
            this.pnlPaid.Controls.Add(this.label6);
            this.pnlPaid.Controls.Add(this.pid);
            this.pnlPaid.Location = new System.Drawing.Point(610, 12);
            this.pnlPaid.Name = "pnlPaid";
            this.pnlPaid.Size = new System.Drawing.Size(265, 85);
            this.pnlPaid.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label6.Location = new System.Drawing.Point(14, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Paid Invoices";
            // 
            // pid
            // 
            this.pid.AutoSize = true;
            this.pid.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.pid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pid.Location = new System.Drawing.Point(10, 32);
            this.pid.Name = "pid";
            this.pid.Size = new System.Drawing.Size(46, 54);
            this.pid.TabIndex = 1;
            this.pid.Text = "0";
            // 
            // pnlUnpaid
            // 
            this.pnlUnpaid.BackColor = System.Drawing.Color.White;
            this.pnlUnpaid.Controls.Add(this.label7);
            this.pnlUnpaid.Controls.Add(this.p);
            this.pnlUnpaid.Location = new System.Drawing.Point(905, 12);
            this.pnlUnpaid.Name = "pnlUnpaid";
            this.pnlUnpaid.Size = new System.Drawing.Size(265, 85);
            this.pnlUnpaid.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label7.Location = new System.Drawing.Point(14, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Unpaid Invoices";
            // 
            // p
            // 
            this.p.AutoSize = true;
            this.p.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.p.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.p.Location = new System.Drawing.Point(10, 32);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(46, 54);
            this.p.TabIndex = 1;
            this.p.Text = "0";
            this.p.Click += new System.EventHandler(this.label7_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 236);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1186, 385);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1218, 637);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reports";
            this.Text = "Reports & Analytics";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlTotalInvoices.ResumeLayout(false);
            this.pnlTotalInvoices.PerformLayout();
            this.pnlTotalAmount.ResumeLayout(false);
            this.pnlTotalAmount.PerformLayout();
            this.pnlPaid.ResumeLayout(false);
            this.pnlPaid.PerformLayout();
            this.pnlUnpaid.ResumeLayout(false);
            this.pnlUnpaid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker datefrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnviewreport;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlTotalInvoices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pa;
        private System.Windows.Forms.Panel pnlTotalAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtotalamount;
        private System.Windows.Forms.Panel pnlPaid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label pid;
        private System.Windows.Forms.Panel pnlUnpaid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label p;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}