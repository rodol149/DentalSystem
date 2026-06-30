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
    public partial class payments : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int paymentID = 0;
        public payments()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }

        private void payments_Load(object sender, EventArgs e)
        {
            LoadInvoices();
            LoadPayments();

            cmbmethod.Items.Clear();
            cmbmethod.Items.Add("Cash");
            cmbmethod.Items.Add("EVC");
            cmbmethod.Items.Add("Bank");

            cmbinvoice.SelectedIndex = -1;
            cmbmethod.SelectedIndex = -1;
        }
        private void LoadInvoices()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

               string query = @"
                                SELECT
                                    i.invoice_id,
                                    p.full_name AS Patient
                                FROM invoices i
                                INNER JOIN patients p
                                ON i.patient_id = p.patient_id";

            MySqlCommand cmd = new MySqlCommand(query, con);

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            cmbinvoice.DataSource = dt;
            cmbinvoice.DisplayMember = "Patient";
            cmbinvoice.ValueMember = "invoice_id";

            cmbinvoice.Refresh();
            con.Close();
        }
        private void LoadPayments()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            string query = @"
                                    SELECT
                                    p.payment_id,
                                    i.invoice_id AS Invoice,
                                    pt.full_name AS Patient,
                                    p.amount AS Amount,
                                    p.payment_method AS Method,
                                    p.payment_date AS Date
                                    FROM payments p
                                    INNER JOIN invoices i
                                    ON p.invoice_id=i.invoice_id
                                    INNER JOIN patients pt
                                    ON i.patient_id=pt.patient_id";

            MySqlDataAdapter da = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
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
                                    p.payment_id,
                                    i.invoice_id AS Invoice,
                                    pt.full_name AS Patient,
                                    p.amount AS Amount,
                                    p.payment_method AS Method,
                                    p.payment_date AS Date
                                    FROM payments p
                                    INNER JOIN invoices i
                                    ON p.invoice_id=i.invoice_id
                                    INNER JOIN patients pt
                                    ON i.patient_id=pt.patient_id
                                    WHERE
                                    pt.full_name LIKE @search
                                    OR p.payment_method LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@search", "%" + txtsearch.Text + "%");

                DataTable dt = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            if (paymentID == 0)
            {
                MessageBox.Show("Please select a payment to update.");
                return;
            }
            if (cmbinvoice.SelectedValue == null || cmbinvoice.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an invoice.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbmethod.Text))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtamount.Text))
            {
                MessageBox.Show("Please enter the payment amount.");
                return;
            }
            if (!decimal.TryParse(txtamount.Text.Trim(), out decimal amount) || amount < 0)
            {
                MessageBox.Show("Payment amount must be a valid positive number.");
                return;
            }

            try
            {
                con.Open();

                // Fetch old invoice_id first
                int oldInvoiceId = 0;
                string queryOld = "SELECT invoice_id FROM payments WHERE payment_id = @id";
                using (MySqlCommand cmdOld = new MySqlCommand(queryOld, con))
                {
                    cmdOld.Parameters.AddWithValue("@id", paymentID);
                    var val = cmdOld.ExecuteScalar();
                    if (val != null && val != DBNull.Value) oldInvoiceId = Convert.ToInt32(val);
                }

                string query = @"UPDATE payments
                                            SET
                                            invoice_id=@invoice,
                                            amount=@amount,
                                            payment_method=@method,
                                            payment_date=@date
                                            WHERE payment_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@invoice", cmbinvoice.SelectedValue);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@method", cmbmethod.Text);
                cmd.Parameters.AddWithValue("@date", date.Value.Date);
                cmd.Parameters.AddWithValue("@id", paymentID);

                cmd.ExecuteNonQuery();
                con.Close();

                // Update both old and new invoice status
                UpdateInvoiceStatus(oldInvoiceId);
                UpdateInvoiceStatus(Convert.ToInt32(cmbinvoice.SelectedValue));

                MessageBox.Show("Updated Successfully");

                LoadPayments();
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (paymentID == 0)
            {
                MessageBox.Show("Please select a payment to delete.");
                return;
            }

            try
            {
                con.Open();

                // Fetch invoice_id first before deleting
                int invoiceId = 0;
                string queryInvoice = "SELECT invoice_id FROM payments WHERE payment_id = @id";
                using (MySqlCommand cmdInv = new MySqlCommand(queryInvoice, con))
                {
                    cmdInv.Parameters.AddWithValue("@id", paymentID);
                    var val = cmdInv.ExecuteScalar();
                    if (val != null && val != DBNull.Value) invoiceId = Convert.ToInt32(val);
                }

                MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM payments WHERE payment_id=@id", con);

                cmd.Parameters.AddWithValue("@id", paymentID);

                cmd.ExecuteNonQuery();
                con.Close();

                // Recalculate status of the invoice
                UpdateInvoiceStatus(invoiceId);

                MessageBox.Show("Deleted Successfully");

                LoadPayments();
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (cmbinvoice.SelectedValue == null || cmbinvoice.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an invoice.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbmethod.Text))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtamount.Text))
            {
                MessageBox.Show("Please enter the payment amount.");
                return;
            }
            if (!decimal.TryParse(txtamount.Text.Trim(), out decimal amount) || amount < 0)
            {
                MessageBox.Show("Payment amount must be a valid positive number.");
                return;
            }

            try
            {
                con.Open();

                string query = @"INSERT INTO payments
                                                        (invoice_id,amount,payment_method,payment_date)
                                                        VALUES
                                                        (@invoice,@amount,@method,@date)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@invoice", cmbinvoice.SelectedValue);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@method", cmbmethod.Text);
                cmd.Parameters.AddWithValue("@date", date.Value.Date);

                cmd.ExecuteNonQuery();
                con.Close();

                // Recalculate status of the invoice
                UpdateInvoiceStatus(Convert.ToInt32(cmbinvoice.SelectedValue));

                MessageBox.Show("Payment Saved Successfully");

                LoadPayments();
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void UpdateInvoiceStatus(int invoiceId)
        {
            if (invoiceId <= 0) return;

            try
            {
                using (MySqlConnection tempCon = new MySqlConnection(connString))
                {
                    tempCon.Open();

                    // 1. Get total invoice amount
                    decimal totalAmount = 0;
                    string amountQuery = "SELECT total_amount FROM invoices WHERE invoice_id = @invoice_id";
                    using (MySqlCommand amountCmd = new MySqlCommand(amountQuery, tempCon))
                    {
                        amountCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                        var val = amountCmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            totalAmount = Convert.ToDecimal(val);
                        }
                    }

                    // 2. Get sum of all payments for this invoice
                    decimal totalPaid = 0;
                    string paidQuery = "SELECT SUM(amount) FROM payments WHERE invoice_id = @invoice_id";
                    using (MySqlCommand paidCmd = new MySqlCommand(paidQuery, tempCon))
                    {
                        paidCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                        var val = paidCmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            totalPaid = Convert.ToDecimal(val);
                        }
                    }

                    // 3. Determine status
                    string newStatus = "Unpaid";
                    if (totalPaid >= totalAmount && totalAmount > 0)
                    {
                        newStatus = "Paid";
                    }
                    else if (totalPaid > 0)
                    {
                        newStatus = "Partial";
                    }

                    // 4. Update invoice status
                    string updateQuery = "UPDATE invoices SET status = @status WHERE invoice_id = @invoice_id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, tempCon))
                    {
                        updateCmd.Parameters.AddWithValue("@status", newStatus);
                        updateCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating invoice status: " + ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
                        paymentID = 0;

                        cmbinvoice.SelectedIndex = -1;
                        cmbmethod.SelectedIndex = -1;

                        txtamount.Clear();

                        date.Value = DateTime.Today;
        }

        private void btnrefresh_Click_1(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                paymentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["payment_id"].Value);

                cmbinvoice.Text = dataGridView1.Rows[e.RowIndex].Cells["Patient"].Value.ToString();

                txtamount.Text = dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString();

                cmbmethod.Text = dataGridView1.Rows[e.RowIndex].Cells["Method"].Value.ToString();

                date.Value = Convert.ToDateTime(
                    dataGridView1.Rows[e.RowIndex].Cells["Date"].Value);
            }
        }
    }
}
