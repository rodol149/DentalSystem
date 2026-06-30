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
using System.Xml.Linq;

namespace DentalSystem
{
    public partial class Doctors : Form
    {
       
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int docotrID = 0;
        public Doctors()
        {
            InitializeComponent();
            con=new MySqlConnection(connString);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void loadDoctors()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = "SELECT * FROM doctors";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
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
        private void Doctors_Load(object sender, EventArgs e)
        {
            loadDoctors();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            loadDoctors();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string fullName = txtfullname.Text.Trim();
            string phone = txtphone.Text.Trim();
            string email = txtemail.Text.Trim();
            string specialization = comspecial.Text;
            string status = cmbstatus.Text;

            // 1. Validation checks
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter the doctor's full name.");
                return;
            }
            if (fullName.Length < 2)
            {
                MessageBox.Show("Full name must be at least 2 characters long.");
                return;
            }
            if (!fullName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '-'))
            {
                MessageBox.Show("Full name can only contain letters, spaces, dots, or hyphens.");
                return;
            }

            if (string.IsNullOrWhiteSpace(specialization))
            {
                MessageBox.Show("Please select a specialization.");
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }
            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain digits only.");
                return;
            }
            if (phone.Length < 7 || phone.Length > 15)
            {
                MessageBox.Show("Phone number must be between 7 and 15 digits long.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address (e.g. name@domain.com).");
                return;
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please select a status.");
                return;
            }

            if (date.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Hire date cannot be in the future.");
                return;
            }

            try
            {
                con.Open();

                // Check duplicate by phone or email
                string checkQuery = "SELECT COUNT(*) FROM doctors WHERE phone = @phone OR email = @email";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@phone", phone);
                    checkCmd.Parameters.AddWithValue("@email", email);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("A doctor with this phone number or email address already exists.");
                        con.Close();
                        return;
                    }
                }

                string query = @"INSERT INTO doctors
        (full_name,specialization,phone,email,hire_date,status)
        VALUES
        (@full_name,@specialization,@phone,@email,@hire_date,@status)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@full_name", fullName);
                cmd.Parameters.AddWithValue("@specialization", specialization);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hire_date", date.Value.Date);
                cmd.Parameters.AddWithValue("@status", status);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor saved successfully");

                loadDoctors();
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtfullname.Clear();
            comspecial.SelectedIndex = -1;
            txtphone.Clear();
            txtemail.Clear();
            cmbstatus.SelectedIndex = -1;
            date.Value = DateTime.Today;
            docotrID = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            docotrID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["doctor_id"].Value);
            txtfullname.Text = dataGridView1.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
            comspecial.Text = dataGridView1.Rows[e.RowIndex].Cells["specialization"].Value.ToString();
            txtphone.Text = dataGridView1.Rows[e.RowIndex].Cells["phone"].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
            date.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["hire_date"].Value);
            cmbstatus.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (docotrID == 0)
            {
                MessageBox.Show("Please select a doctor to update.");
                return;
            }

            string fullName = txtfullname.Text.Trim();
            string phone = txtphone.Text.Trim();
            string email = txtemail.Text.Trim();
            string specialization = comspecial.Text;
            string status = cmbstatus.Text;

            // 1. Validation checks
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter the doctor's full name.");
                return;
            }
            if (fullName.Length < 2)
            {
                MessageBox.Show("Full name must be at least 2 characters long.");
                return;
            }
            if (!fullName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '-'))
            {
                MessageBox.Show("Full name can only contain letters, spaces, dots, or hyphens.");
                return;
            }

            if (string.IsNullOrWhiteSpace(specialization))
            {
                MessageBox.Show("Please select a specialization.");
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }
            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain digits only.");
                return;
            }
            if (phone.Length < 7 || phone.Length > 15)
            {
                MessageBox.Show("Phone number must be between 7 and 15 digits long.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address (e.g. name@domain.com).");
                return;
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please select a status.");
                return;
            }

            if (date.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Hire date cannot be in the future.");
                return;
            }

            try
            {
                con.Open();

                // Check duplicate excluding current doctor ID
                string checkQuery = "SELECT COUNT(*) FROM doctors WHERE (phone = @phone OR email = @email) AND doctor_id != @doctor_id";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@phone", phone);
                    checkCmd.Parameters.AddWithValue("@email", email);
                    checkCmd.Parameters.AddWithValue("@doctor_id", docotrID);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Another doctor with this phone number or email address already exists.");
                        con.Close();
                        return;
                    }
                }

                string query = @"UPDATE doctors
                          SET full_name=@full_name,
                              specialization=@specialization,
                              phone=@phone,
                              email=@email,
                              hire_date=@hire_date,
                              status=@status
                          WHERE doctor_id=@doctor_id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@full_name", fullName);
                cmd.Parameters.AddWithValue("@specialization", specialization);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hire_date", date.Value.Date);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@doctor_id", docotrID);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor updated successfully");

                loadDoctors();
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
            if (docotrID == 0)
            {
                MessageBox.Show("Please select a doctor to delete.");
                return;
            }

            try
            {
                con.Open();

                string query = "DELETE FROM doctors WHERE doctor_id=@doctor_id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@doctor_id", docotrID);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor deleted successfully");
                loadDoctors();
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            docotrID = Convert.ToInt32(
                dataGridView1.Rows[e.RowIndex]
                .Cells["doctor_id"].Value);

            txtfullname.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["full_name"].Value.ToString();

            comspecial.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["specialization"].Value.ToString();

            txtphone.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["phone"].Value.ToString();

            txtemail.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["email"].Value.ToString();

            date.Value =
                Convert.ToDateTime(
                dataGridView1.Rows[e.RowIndex]
                .Cells["hire_date"].Value);

            cmbstatus.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["status"].Value.ToString();
        }
    }
    
    
    

    
}
