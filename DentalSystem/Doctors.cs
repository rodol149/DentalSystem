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
            if (string.IsNullOrWhiteSpace(txtfullname.Text) ||
              string.IsNullOrWhiteSpace(txtphone.Text) ||
              string.IsNullOrWhiteSpace(txtemail.Text) || string.IsNullOrWhiteSpace(comspecial.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                con.Open();

                string query = @"INSERT INTO doctors
        (full_name,specialization,phone,email,hire_date,status)
        VALUES
        (@full_name,@specialization,@phone,@email,@hire_date,@status)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@full_name", txtfullname.Text);
                cmd.Parameters.AddWithValue("@specialization", comspecial.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@hire_date", date.Value.Date);
                cmd.Parameters.AddWithValue("@status", cmbstatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Doctor saved successfully");

                loadDoctors();
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
            txtfullname.Clear();
            comspecial.SelectedIndex = -1;
            txtphone.Clear();
            txtemail.Clear();
            cmbstatus.SelectedIndex = -1;

            date.Value = DateTime.Now;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtfullname.Text) ||
                string.IsNullOrWhiteSpace(txtphone.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) || string.IsNullOrWhiteSpace(comspecial.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            try
            {
                con.Open();

                string query = @"UPDATE doctors
                         SET full_name=@full_name,
                             specialization=@specialization,
                             phone=@phone,
                             email=@email,
                             hire_date=@hire_date,
                             status=@status
                         WHERE doctor_id=@doctor_id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@full_name", txtfullname.Text);
                cmd.Parameters.AddWithValue("@specialization", comspecial.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@hire_date", date.Value.Date);
                cmd.Parameters.AddWithValue("@status", cmbstatus.Text);
                cmd.Parameters.AddWithValue("@doctor_id", docotrID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Doctor updated successfully");

                loadDoctors();
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
            if (string.IsNullOrWhiteSpace(txtfullname.Text) ||
              string.IsNullOrWhiteSpace(txtphone.Text) ||
              string.IsNullOrWhiteSpace(txtemail.Text) || string.IsNullOrWhiteSpace(comspecial.Text))
            {
                MessageBox.Show("Please choose what to delete.");
                return;
            }
            try
            {
                con.Open();

                string query =
                    "DELETE FROM doctors WHERE doctor_id=@doctor_id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@doctor_id", docotrID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Doctor deleted successfully");
                loadDoctors();
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
