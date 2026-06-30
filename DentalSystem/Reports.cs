using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalSystem
{
    public partial class Reports : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        public Reports()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }



        private void btnviewreport_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"
                                                SELECT
                                                    i.invoice_id AS 'Invoice ID',
                                                    p.full_name AS Patient,
                                                    s.service_name AS Treatment,
                                                    i.total_amount AS Amount,
                                                    pay.payment_method AS Method,
                                                    i.invoice_date AS Date,
                                                    i.status AS Status
                                                FROM invoices i
                                                INNER JOIN patients p
                                                    ON i.patient_id = p.patient_id
                                                INNER JOIN treatments t
                                                    ON i.treatment_id = t.treatment_id
                                                INNER JOIN services s
                                                    ON t.service_id = s.service_id
                                                LEFT JOIN payments pay
                                                    ON i.invoice_id = pay.invoice_id
                                                WHERE i.invoice_date BETWEEN @from AND @to";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@from", datefrom.Value.Date);
                cmd.Parameters.AddWithValue("@to", dateto.Value.Date);

                DataTable dt = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                UpdateSummary(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();

            pd.Document = printDocument1;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }

        }
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Fonts
            Font fontTitle = new Font("Segoe UI", 18, FontStyle.Bold);
            Font fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontBody = new Font("Segoe UI", 9, FontStyle.Regular);
            Font fontBold = new Font("Segoe UI", 9, FontStyle.Bold);
            Font fontFooter = new Font("Segoe UI", 8, FontStyle.Italic);

            // Colors
            Brush brushNavy = new SolidBrush(Color.FromArgb(30, 58, 95));
            Brush brushText = new SolidBrush(Color.FromArgb(44, 62, 80));
            Pen penNavy = new Pen(Color.FromArgb(30, 58, 95), 2);
            Pen penLight = new Pen(Color.FromArgb(220, 224, 230), 1);

            int y = 50;

            // 1. Report Header Banner
            g.DrawString("DENTAL CLINIC SYSTEM", fontTitle, brushNavy, 50, y);
            y += 32;
            g.DrawString("Clinic Invoices & Payments Summary Report", fontBold, brushText, 50, y);
            
            string periodStr = $"Filter Range: {datefrom.Value.ToString("dd MMM yyyy")} to {dateto.Value.ToString("dd MMM yyyy")}";
            g.DrawString(periodStr, fontBody, brushText, 500, y);
            y += 20;
            g.DrawLine(penNavy, 50, y, 780, y);
            y += 25;

            // 2. Summary stats layout
            g.DrawString("SUMMARY METRICS", fontHeader, brushNavy, 50, y);
            y += 22;

            g.DrawString($"Total Invoices: {pa.Text}", fontBold, brushText, 60, y);
            g.DrawString($"Total Amount: {lbtotalamount.Text}", fontBold, brushText, 220, y);
            g.DrawString($"Paid Amount: {pid.Text}", fontBold, brushText, 420, y);
            g.DrawString($"Unpaid Balance: {p.Text}", fontBold, brushText, 620, y);
            y += 25;
            g.DrawLine(penLight, 50, y, 780, y);
            y += 20;

            // 3. Grid Table Headers
            g.DrawString("INVOICES & TREATMENTS LIST", fontHeader, brushNavy, 50, y);
            y += 25;

            g.DrawString("Invoice ID", fontHeader, brushNavy, 50, y);
            g.DrawString("Patient Name", fontHeader, brushNavy, 130, y);
            g.DrawString("Treatment Detail", fontHeader, brushNavy, 280, y);
            g.DrawString("Amount", fontHeader, brushNavy, 460, y);
            g.DrawString("Method", fontHeader, brushNavy, 540, y);
            g.DrawString("Date", fontHeader, brushNavy, 620, y);
            g.DrawString("Status", fontHeader, brushNavy, 710, y);
            y += 22;
            g.DrawLine(penNavy, 50, y, 780, y);
            y += 8;

            // 4. Draw Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (!row.Visible) continue;

                string invId = row.Cells["Invoice ID"].Value?.ToString() ?? "";
                string patientName = row.Cells["Patient"].Value?.ToString() ?? "";
                string treatmentName = row.Cells["Treatment"].Value?.ToString() ?? "";
                string amountVal = row.Cells["Amount"].Value != null ? "$" + Convert.ToDecimal(row.Cells["Amount"].Value).ToString("N2") : "$0.00";
                string methodVal = row.Cells["Method"].Value?.ToString() ?? "N/A";
                string dateVal = row.Cells["Date"].Value != null ? Convert.ToDateTime(row.Cells["Date"].Value).ToString("dd-MM-yyyy") : "";
                string statusVal = row.Cells["Status"].Value?.ToString() ?? "";

                // Clip text length to fit columns neatly
                if (patientName.Length > 20) patientName = patientName.Substring(0, 18) + "..";
                if (treatmentName.Length > 22) treatmentName = treatmentName.Substring(0, 20) + "..";

                g.DrawString(invId, fontBody, brushText, 50, y);
                g.DrawString(patientName, fontBody, brushText, 130, y);
                g.DrawString(treatmentName, fontBody, brushText, 280, y);
                g.DrawString(amountVal, fontBody, brushText, 460, y);
                g.DrawString(methodVal, fontBody, brushText, 540, y);
                g.DrawString(dateVal, fontBody, brushText, 620, y);

                // Status Coloring
                Brush statusBrush = brushText;
                if (statusVal == "Paid") statusBrush = new SolidBrush(Color.FromArgb(39, 174, 96));
                else if (statusVal == "Partial") statusBrush = new SolidBrush(Color.FromArgb(211, 84, 0));
                else if (statusVal == "Unpaid") statusBrush = new SolidBrush(Color.FromArgb(192, 57, 43));

                g.DrawString(statusVal, fontBold, statusBrush, 710, y);

                y += 24;
                g.DrawLine(penLight, 50, y, 780, y);
                y += 6;

                // Stop drawing if we exceed page height bounds (prevent overflow layout errors)
                if (y > 1050) break;
            }

            // 5. Draw Footer
            y = 1100;
            g.DrawLine(penLight, 50, y, 780, y);
            y += 8;
            g.DrawString($"Report generated automatically by Dental Clinic Management System on {DateTime.Now.ToString("F")}", fontFooter, brushText, 50, y);
            g.DrawString("Page 1 of 1", fontFooter, brushText, 710, y);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            datefrom.Value = DateTime.Today.AddMonths(-1);
            dateto.Value = DateTime.Today;
            dataGridView1.RowHeadersVisible = false;

            LoadReport();
        }
        private void LoadReport( )
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"
                                    SELECT
                                        i.invoice_id AS 'Invoice ID',
                                        p.full_name AS Patient,
                                        s.service_name AS Treatment,
                                        i.total_amount AS Amount,
                                        pay.payment_method AS Method,
                                        i.invoice_date AS Date,
                                        i.status AS Status
                                    FROM invoices i
                                    INNER JOIN patients p
                                        ON i.patient_id = p.patient_id
                                    INNER JOIN treatments t
                                        ON i.treatment_id = t.treatment_id
                                    INNER JOIN services s
                                        ON t.service_id = s.service_id
                                    LEFT JOIN payments pay
                                        ON i.invoice_id = pay.invoice_id";

                DataTable dt = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                UpdateSummary(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void title_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager cm =
                (CurrencyManager)BindingContext[dataGridView1.DataSource];

            cm.SuspendBinding();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool visible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null &&
                        cell.Value.ToString().ToLower().Contains(txtsearch.Text.ToLower()))
                    {
                        visible = true;
                        break;
                    }
                }

                row.Visible = visible;
            }

            cm.ResumeBinding();
        }

        private void UpdateSummary(DataTable dt)
        {
            pa.Text = dt.Rows.Count.ToString();

            decimal total = 0;
            decimal paid = 0;
            decimal unpaid = 0;

            foreach (DataRow row in dt.Rows)
            {
                decimal amount = Convert.ToDecimal(row["Amount"]);

                total += amount;

                if (row["Status"].ToString() == "Paid")
                    paid += amount;
                else
                    unpaid += amount;
            }

            lbtotalamount.Text = "$" + total.ToString("N2");
            pid.Text = "$" + paid.ToString("N2");
            p.Text = "$" + unpaid.ToString("N2");
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsearch.Clear();

            datefrom.Value = DateTime.Today.AddMonths(-1);
            dateto.Value = DateTime.Today;

            LoadReport();

            MessageBox.Show("Report Refreshed Successfully");
        }
    }
    
    
}
