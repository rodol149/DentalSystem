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
    public partial class treatment : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int treatmentID = 0;
        public treatment()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }
       private void  Loadtreatments()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"
                                     SELECT
                                            t.treatment_id,
                                            t.appointment_id AS 'Appointment No',
                                            s.service_name AS 'Service',
                                            d.full_name AS 'Doctor',
                                            t.treatment_fee AS 'Treatment Fee',
                                            t.treatment_date AS 'Date',
                                            t.notes AS 'Notes'
                                        FROM treatments t
                                        INNER JOIN services s ON t.service_id = s.service_id
                                        INNER JOIN doctors d ON t.doctor_id = d.doctor_id
                                        WHERE s.service_name LIKE @search
                                           OR d.full_name LIKE @search
                                           OR t.appointment_id LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + txtsearch.Text + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;


                if (dataGridView1.Columns["treatment_id"] != null)
                {
                    dataGridView1.Columns["treatment_id"].Visible = false;
                }
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
        


        private void treatment_Load(object sender, EventArgs e)
        {
            LoadAppointmentCombo();
            LoadServices();
            LoadDoctors();
            Loadtreatments();

            cmbappointment.SelectedIndex = -1;
            cmbservice.SelectedIndex = -1;
            cmbdoctor.SelectedIndex = -1;
        }
        private void LoadServices()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand(
                "SELECT service_id, service_name FROM services", con);

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cmbservice.DataSource = dt;
            cmbservice.DisplayMember = "service_name";
            cmbservice.ValueMember = "service_id";

            con.Close();
        }
        private void LoadDoctors()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand(
                "SELECT doctor_id, full_name FROM doctors", con);

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cmbdoctor.DataSource = dt;
            cmbdoctor.DisplayMember = "full_name";
            cmbdoctor.ValueMember = "doctor_id";

            con.Close();
        }
        private void LoadAppointments()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            string query = @"
                                SELECT
                                    treatment_id,
                                    appointment_id,
                                    s.service_name AS Service,
                                    d.full_name AS Doctor,
                                    treatment_fee,
                                    treatment_date,
                                    notes
                                FROM treatments t
                                INNER JOIN services s
                                    ON t.service_id = s.service_id
                                INNER JOIN doctors d
                                    ON t.doctor_id = d.doctor_id";

            MySqlDataAdapter da =
                new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void LoadAppointmentCombo()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            MySqlCommand cmd = new MySqlCommand(
                "SELECT appointment_id FROM appointments", con);

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            cmbappointment.DataSource = dt;
            cmbappointment.DisplayMember = "appointment_id";
            cmbappointment.ValueMember = "appointment_id";

            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"
                                     SELECT
                                            t.treatment_id,
                                            t.appointment_id AS 'Appointment No',
                                            s.service_name AS 'Service',
                                            d.full_name AS 'Doctor',
                                            t.treatment_fee AS 'Treatment Fee',
                                            t.treatment_date AS 'Date',
                                            t.notes AS 'Notes'
                                        FROM treatments t
                                        INNER JOIN services s ON t.service_id = s.service_id
                                        INNER JOIN doctors d ON t.doctor_id = d.doctor_id
                                        WHERE s.service_name LIKE @search
                                           OR d.full_name LIKE @search
                                           OR t.appointment_id LIKE @search";

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

        private void btnsave_Click(object sender, EventArgs e)
        {
          try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                string query = @"INSERT INTO treatments
                        (appointment_id, service_id, doctor_id,
                         treatment_fee, treatment_date, notes)
                         VALUES
                        (@appointment_id, @service_id, @doctor_id,
                         @fee, @date, @notes)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@appointment_id", cmbappointment.SelectedValue);
                cmd.Parameters.AddWithValue("@service_id", cmbservice.SelectedValue);
                cmd.Parameters.AddWithValue("@doctor_id", cmbdoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@fee", txtfee.Text);
                cmd.Parameters.AddWithValue("@date", treatmentdate.Value.Date);
                cmd.Parameters.AddWithValue("@notes", txtnote.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Treatment Saved Successfully");

                LoadAppointments();
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
                con.Open();

                string query = @"UPDATE treatments
                        SET appointment_id=@appointment,
                            service_id=@service,
                            doctor_id=@doctor,
                            treatment_fee=@fee,
                            treatment_date=@date,
                            notes=@notes
                        WHERE treatment_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@appointment", cmbappointment.SelectedValue);
                cmd.Parameters.AddWithValue("@service", cmbservice.SelectedValue);
                cmd.Parameters.AddWithValue("@doctor", cmbdoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@fee", txtfee.Text);
                cmd.Parameters.AddWithValue("@date", treatmentdate.Value.Date);
                cmd.Parameters.AddWithValue("@notes", txtnote.Text);
                cmd.Parameters.AddWithValue("@id", treatmentID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Treatment Updated Successfully");

                Loadtreatments();
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
                    "DELETE FROM treatments WHERE treatment_id=@id";

                MySqlCommand cmd =
                    new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", treatmentID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Treatment Deleted Successfully");

                Loadtreatments();
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
            treatmentID = 0;

            cmbappointment.SelectedIndex = -1;
            cmbservice.SelectedIndex = -1;
            cmbdoctor.SelectedIndex = -1;

            txtfee.Clear();
            txtnote.Clear();

            treatmentdate.Value = DateTime.Today;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            Loadtreatments();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                treatmentID = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["treatment_id"].Value);

                cmbappointment.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Appointment No"].Value.ToString();

                cmbservice.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Service"].Value.ToString();

                cmbdoctor.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Doctor"].Value.ToString();

                txtfee.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Treatment Fee"].Value.ToString();

                treatmentdate.Value =
                    Convert.ToDateTime(
                        dataGridView1.Rows[e.RowIndex].Cells["Date"].Value);

                txtnote.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Notes"].Value.ToString();
            }
        }
    }
}
