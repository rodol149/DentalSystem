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
    public partial class Patient : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int patientID = 0;
        public Patient()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string query = "select * from patients";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            string fullName = txtfullname.Text.Trim();
            string phone = txtphone.Text.Trim();
            string email = txtemail.Text.Trim();
            string gender = cmbg.Text;
            string address = txtaddress.Text.Trim();

            // 1. Validation checks
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter the patient's full name.");
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

            if (string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please select a gender.");
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

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address (e.g. name@domain.com).");
                    return;
                }
            }

            if (dob.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Date of birth must be a past date.");
                return;
            }

            try
            {
                con.Open();

                // Check duplicate by name or phone
                string checkQuery = "SELECT COUNT(*) FROM patients WHERE phone = @phone OR full_name = @fullname";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@phone", phone);
                    checkCmd.Parameters.AddWithValue("@fullname", fullName);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("A patient with this name or phone number already exists.");
                        con.Close();
                        return;
                    }
                }

                String query = @"insert into patients (full_name, gender, phone, email, address, date_of_birth) values (@fullname, @gender, @phone, @email, @address, @date_of_birth)";
                MySqlCommand cm = new MySqlCommand(query, con);
                cm.Parameters.AddWithValue("@fullname", fullName);
                cm.Parameters.AddWithValue("@gender", gender);
                cm.Parameters.AddWithValue("@phone", phone);
                cm.Parameters.AddWithValue("@email", email);
                cm.Parameters.AddWithValue("@address", address);
                cm.Parameters.AddWithValue("@date_of_birth", dob.Value.Date);

                cm.ExecuteNonQuery();
                con.Close();

                Patient_Load(null, null);
                MessageBox.Show("Patient added successfully");
                btnclear_Click(null, null); // Clear textboxes to prevent double saving
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            patientID = Convert.ToInt32(
              dataGridView.Rows[e.RowIndex].Cells["patient_id"].Value);

            txtfullname.Text =
                dataGridView.Rows[e.RowIndex].Cells["full_name"].Value.ToString();
            cmbg.Text =
                dataGridView.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            txtphone.Text =
                dataGridView.Rows[e.RowIndex].Cells["phone"].Value.ToString();

            txtemail.Text =
                dataGridView.Rows[e.RowIndex].Cells["email"].Value.ToString();

            txtaddress.Text =
                dataGridView.Rows[e.RowIndex].Cells["address"].Value.ToString();

            dob.Value =
                Convert.ToDateTime(
                dataGridView.Rows[e.RowIndex].Cells["date_of_birth"].Value);

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (patientID == 0)
            {
                MessageBox.Show("Please select a patient to update.");
                return;
            }

            string fullName = txtfullname.Text.Trim();
            string phone = txtphone.Text.Trim();
            string email = txtemail.Text.Trim();
            string gender = cmbg.Text;
            string address = txtaddress.Text.Trim();

            // 1. Validation checks
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter the patient's full name.");
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

            if (string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please select a gender.");
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

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address (e.g. name@domain.com).");
                    return;
                }
            }

            if (dob.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Date of birth must be a past date.");
                return;
            }

            try {
                con.Open();

                // Check duplicate by name or phone excluding current patient ID
                string checkQuery = "SELECT COUNT(*) FROM patients WHERE (phone = @phone OR full_name = @fullname) AND patient_id != @patient_id";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@phone", phone);
                    checkCmd.Parameters.AddWithValue("@fullname", fullName);
                    checkCmd.Parameters.AddWithValue("@patient_id", patientID);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Another patient with this name or phone number already exists.");
                        con.Close();
                        return;
                    }
                }

                string query = @"update patients set full_name=@fullname, gender=@gender, phone=@phone, 
                            email=@email, address=@address, date_of_birth=@date_of_birth where patient_id = @patient_id";
                MySqlCommand cm = new MySqlCommand(query, con);
                cm.Parameters.AddWithValue("@fullname", fullName);
                cm.Parameters.AddWithValue("@gender", gender);
                cm.Parameters.AddWithValue("@phone", phone);
                cm.Parameters.AddWithValue("@email", email);
                cm.Parameters.AddWithValue("@address", address);
                cm.Parameters.AddWithValue("@date_of_birth", dob.Value.Date);
                cm.Parameters.AddWithValue("@patient_id", patientID);

                cm.ExecuteNonQuery();
                con.Close();

                Patient_Load(null,null);
                MessageBox.Show("Patient updated successfully");
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (patientID == 0)
            {
                MessageBox.Show("Please select a patient to delete.");
                return;
            }

            try
            {
                con.Open();
                string query = @"delete from patients where patient_id = @patient_id";
                MySqlCommand cm = new MySqlCommand(query, con);
                cm.Parameters.AddWithValue("@patient_id", patientID);
                cm.ExecuteNonQuery();
                con.Close();

                Patient_Load(null, null);
                MessageBox.Show("Patient deleted successfully");
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
            txtphone.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            cmbg.SelectedIndex = -1;
            dob.Value = DateTime.Now;
            patientID = 0;
        }

        private void txtfullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            patientID = Convert.ToInt32(
            dataGridView.Rows[e.RowIndex].Cells["patient_id"].Value);

            txtfullname.Text =
                dataGridView.Rows[e.RowIndex].Cells["full_name"].Value.ToString();

            cmbg.Text =
                dataGridView.Rows[e.RowIndex].Cells["gender"].Value.ToString();

            dob.Value =
                Convert.ToDateTime(
                dataGridView.Rows[e.RowIndex].Cells["date_of_birth"].Value);

            txtphone.Text =
                dataGridView.Rows[e.RowIndex].Cells["phone"].Value.ToString();

            txtemail.Text =
                dataGridView.Rows[e.RowIndex].Cells["email"].Value.ToString();

            txtaddress.Text =
                dataGridView.Rows[e.RowIndex].Cells["address"].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
