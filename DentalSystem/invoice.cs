using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalSystem
{
    public partial class invoice : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int invoiceID = 0;
        public invoice()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }
        private void LaodInvoices()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            string query = @"
                                SELECT
                                    i.invoice_id,
                                    p.full_name AS Patient,
                                    s.service_name AS Treatment,
                                    i.total_amount AS Amount,
                                    i.invoice_date AS Date,
                                    i.status AS Status
                                FROM invoices i
                                INNER JOIN patients p
                                    ON i.patient_id = p.patient_id
                                INNER JOIN treatments t
                                    ON i.treatment_id = t.treatment_id
                                INNER JOIN services s
                                    ON t.service_id = s.service_id";

            MySqlDataAdapter da =
                new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void LoadTreatments()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            MySqlCommand cmd = new MySqlCommand(
                                         @"SELECT
                                        t.treatment_id,
                                        s.service_name
                                      FROM treatments t
                                      INNER JOIN services s
                                          ON t.service_id = s.service_id",
                                                     con);

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cmbtr.DataSource = dt;
            cmbtr.DisplayMember = "service_name";
            cmbtr.ValueMember = "treatment_id";

            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void invoice_Load(object sender, EventArgs e)
        {
           LoadPatients();
            LoadTreatments();
            LaodInvoices();

            cmbstatus.Items.Add("Paid");
            cmbstatus.Items.Add("Partial");
            cmbstatus.Items.Add("Unpaid");

            cmbpatient.SelectedIndex = -1;
            cmbtr.SelectedIndex = -1;
            cmbstatus.SelectedIndex = -1;
        }
        private void LoadPatients()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            MySqlCommand cmd = new MySqlCommand(
                "SELECT patient_id, full_name FROM patients", con);

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cmbpatient.DataSource = dt;
            cmbpatient.DisplayMember = "full_name";
            cmbpatient.ValueMember = "patient_id";

            con.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"INSERT INTO invoices
                        (patient_id, treatment_id,
                         invoice_date, total_amount, status)
                         VALUES
                        (@patient, @treatment,
                         @date, @amount, @status)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@patient",
                    cmbpatient.SelectedValue);

                cmd.Parameters.AddWithValue("@treatment",
                    cmbtr.SelectedValue);

                cmd.Parameters.AddWithValue("@date",
                    date.Value.Date);

                cmd.Parameters.AddWithValue("@amount",
                    txtamount.Text);

                cmd.Parameters.AddWithValue("@status",
                    cmbstatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Invoice Saved Successfully");

                LaodInvoices();
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"UPDATE invoices
                        SET patient_id=@patient,
                            treatment_id=@treatment,
                            invoice_date=@date,
                            total_amount=@amount,
                            status=@status
                        WHERE invoice_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@patient", cmbpatient.SelectedValue);
                cmd.Parameters.AddWithValue("@treatment", cmbtr.SelectedValue);
                cmd.Parameters.AddWithValue("@date", date.Value.Date);
                cmd.Parameters.AddWithValue("@amount", txtamount.Text);
                cmd.Parameters.AddWithValue("@status", cmbstatus.Text);
                cmd.Parameters.AddWithValue("@id", invoiceID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Invoice Updated Successfully");

                LaodInvoices();
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

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query =
                    "DELETE FROM invoices WHERE invoice_id=@id";

                MySqlCommand cmd =
                    new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", invoiceID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Invoice Deleted Successfully");

                LaodInvoices();
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            invoiceID = 0;

            cmbpatient.SelectedIndex = -1;
            cmbtr.SelectedIndex = -1;

            txtamount.Clear();

            cmbstatus.SelectedIndex = -1;

            date.Value = DateTime.Today;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LaodInvoices();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"
                                    SELECT
                                        i.invoice_id,
                                        p.full_name AS Patient,
                                        s.service_name AS Treatment,
                                        i.total_amount AS Amount,
                                        i.invoice_date AS Date,
                                        i.status AS Status
                                    FROM invoices i
                                    INNER JOIN patients p
                                        ON i.patient_id = p.patient_id
                                    INNER JOIN treatments t
                                        ON i.treatment_id = t.treatment_id
                                    INNER JOIN services s
                                        ON t.service_id = s.service_id
                                    WHERE p.full_name LIKE @search
                                       OR s.service_name LIKE @search
                                       OR i.status LIKE @search";

                MySqlCommand cmd =
                    new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@search",
                    "%" + txtsearch.Text.Trim() + "%");

                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                invoiceID = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["invoice_id"].Value);

                cmbpatient.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Patient"].Value.ToString();

                cmbtr.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Treatment"].Value.ToString();

                txtamount.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString();

                date.Value =
                    Convert.ToDateTime(
                        dataGridView1.Rows[e.RowIndex].Cells["Date"].Value);

                cmbstatus.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            }
        }
    }

}
