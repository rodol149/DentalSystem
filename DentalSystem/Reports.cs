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

            Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);

            dataGridView1.DrawToBitmap(bmp,
                new Rectangle(0, 0, bmp.Width, bmp.Height));

            e.Graphics.DrawImage(bmp, 20, 20);
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
