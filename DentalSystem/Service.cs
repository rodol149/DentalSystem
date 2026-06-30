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
    public partial class Service : Form
    {
        string connstring = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int serviceID= 0;
        public Service()
        {
            InitializeComponent();
            con = new MySqlConnection(connstring);
        }
        private void Service_Load_1(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void LoadServices()
        {

            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = "SELECT * FROM services";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtservicename.Text) ||
       string.IsNullOrWhiteSpace(txtfee.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }
            try
            {
                con.Open();

                string query = @"INSERT INTO services
        (service_name, standard_fee, description)
        VALUES
        (@service_name, @standard_fee, @description)";

                MySqlCommand cm = new MySqlCommand(query, con);

                cm.Parameters.AddWithValue("@service_name", txtservicename.Text);
                cm.Parameters.AddWithValue("@standard_fee", txtfee.Text);
                cm.Parameters.AddWithValue("@description", txtdes.Text);

                cm.ExecuteNonQuery();

                MessageBox.Show("Service saved successfully");

                LoadServices();
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
                serviceID = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["service_id"].Value);

                txtservicename.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["service_name"].Value.ToString();

                txtfee.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["standard_fee"].Value.ToString();

                txtdes.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = @"UPDATE services
        SET service_name=@service_name,
            standard_fee=@standard_fee,
            description=@description
        WHERE service_id=@service_id";

                MySqlCommand cm = new MySqlCommand(query, con);

                cm.Parameters.AddWithValue("@service_name", txtservicename.Text);
                cm.Parameters.AddWithValue("@standard_fee", txtfee.Text);
                cm.Parameters.AddWithValue("@description", txtdes.Text);
                cm.Parameters.AddWithValue("@service_id", serviceID);

                cm.ExecuteNonQuery();

                MessageBox.Show("Service updated successfully");

                LoadServices();
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
                con.Open();

                string query =
                    "DELETE FROM services WHERE service_id=@service_id";

                MySqlCommand cm = new MySqlCommand(query, con);

                cm.Parameters.AddWithValue("@service_id", serviceID);

                cm.ExecuteNonQuery();

                MessageBox.Show("Service deleted successfully");

                LoadServices();
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
            txtservicename.Clear();
            txtfee.Clear();
            txtdes.Clear();
            serviceID = 0;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try{
                con.Open();

                string query = @"SELECT * FROM services
                                            WHERE service_name LIKE @search
                                            OR description LIKE @search
                                            OR CAST(standard_fee AS CHAR) LIKE @search";

                MySqlDataAdapter da =
                    new MySqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue("@search",
                                         "%" + txtsearch.Text.Trim() + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

       
    }
    
    
}
