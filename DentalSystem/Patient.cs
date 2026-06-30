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
            try
            {
                con.Open();
                String query = @"insert into patients (full_name, gender, phone, email, address, date_of_birth) values (@fullname, @gender, @phone, @email, @address, @date_of_birth)";
                MySqlCommand cm = new MySqlCommand(query, con);
                cm.Parameters.AddWithValue("@fullname", txtfullname.Text);
                cm.Parameters.AddWithValue("@gender", cmbg.Text);
                cm.Parameters.AddWithValue("@phone", txtphone.Text);
                cm.Parameters.AddWithValue("@email", txtemail.Text);
                cm.Parameters.AddWithValue("@address", txtaddress.Text);
                cm.Parameters.AddWithValue("@date_of_birth", dob.Value.Date);

                cm.ExecuteNonQuery();
                Patient_Load(null, null);
                MessageBox.Show("Patient added successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
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
            try {
                con.Open();
                string query = @"update patients set full_name=@fullname, gender=@gender, phone=@phone, 
                            email=@email, address=@address, date_of_birth=@date_of_birth where patient_id = @patient_id";
                MySqlCommand cm = new MySqlCommand(query, con);
                cm.Parameters.AddWithValue("@fullname", txtfullname.Text);
                cm.Parameters.AddWithValue("@gender", cmbg.Text);
                cm.Parameters.AddWithValue("@phone", txtphone.Text);
                cm.Parameters.AddWithValue("@email", txtemail.Text);
                cm.Parameters.AddWithValue("@address", txtaddress.Text);
                cm.Parameters.AddWithValue("@date_of_birth", dob.Value.Date);
                cm.Parameters.AddWithValue("@patient_id", patientID);

                cm.ExecuteNonQuery();
                Patient_Load(null,null);
                MessageBox.Show("Patient updated successfully");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = @"delete from patients where patient_id = @patient_id";
            MySqlCommand cm = new MySqlCommand(query, con);
            cm.Parameters.AddWithValue("@patient_id", patientID);
            cm.ExecuteNonQuery();
            Patient_Load(null, null);
            MessageBox.Show("Patient deleted successfully");
            con.Close();
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
