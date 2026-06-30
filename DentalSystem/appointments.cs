using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class appointments : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        int appointmentID = 0;

        public appointments()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);

        }

        private void appointments_Load(object sender, EventArgs e)
        {
            LoadAppointments();
            LoadPatients();
            LoadDoctors();

            cmbstatus.Items.Add("Scheduled");
            cmbstatus.Items.Add("Completed");
            cmbstatus.Items.Add("Cancelled");
            cmbstatus.SelectedIndex = 0;



            cmbpatient.SelectedIndex = -1;
            cmbdoctor.SelectedIndex = -1;
            cmbstatus.SelectedIndex = -1;
            appdate.Format = DateTimePickerFormat.Short;
            apptime.Format = DateTimePickerFormat.Time;
            apptime.ShowUpDown = true;

            

        }

        private void LoadPatients()
        {
            con.Open();
            MySqlCommand cmd =
                new MySqlCommand("SELECT patient_id, full_name FROM patients", con);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            cmbpatient.DataSource = dt;
            cmbpatient.DisplayMember = "full_name";
            cmbpatient.ValueMember = "patient_id";

            con.Close();
        }

        private void LoadDoctors()
        {
            con.Open();

            MySqlCommand cmd =
                new MySqlCommand("SELECT doctor_id, full_name FROM doctors", con);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            cmbdoctor.DataSource = dt;
            cmbdoctor.DisplayMember = "full_name";
            cmbdoctor.ValueMember = "doctor_id";

            con.Close();
        }
        private void LoadAppointments()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string query = @"SELECT a.appointment_id,
                                       a.patient_id,
                                       a.doctor_id,
                                       p.full_name AS Patient,
                                       d.full_name AS Doctor,
                                       a.appointment_date,
                                       a.appointment_time,
                                       a.status,
                                       a.notes
                                FROM appointments a
                                INNER JOIN patients p ON a.patient_id = p.patient_id
                                INNER JOIN doctors d ON a.doctor_id = d.doctor_id";
                MySqlDataAdapter da =
                    new MySqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["patient_id"].Visible = false;
                dataGridView1.Columns["doctor_id"].Visible = false;
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
                appointmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["appointment_id"].Value);

                cmbpatient.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["patient_id"].Value;

                cmbdoctor.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["doctor_id"].Value;

                appdate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["appointment_date"].Value);
                apptime.Value = DateTime.Today.Add(TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells["appointment_time"].Value.ToString()));

                cmbstatus.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();

                txtnote.Text = dataGridView1.Rows[e.RowIndex].Cells["notes"].Value.ToString();
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cmbpatient.SelectedValue == null || cmbpatient.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a patient.");
                return;
            }
            if (cmbdoctor.SelectedValue == null || cmbdoctor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a doctor.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbstatus.Text))
            {
                MessageBox.Show("Please select a status.");
                return;
            }
            if (appdate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Appointment date cannot be in the past.");
                return;
            }

            try
            {
                con.Open();
                string query = @"INSERT INTO appointments(patient_id,doctor_id,appointment_date,appointment_time,status,notes) VALUES (@patient,@doctor,@date,@time,@status,@notes)";

                MySqlCommand cmd =
                    new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@patient",
                    cmbpatient.SelectedValue);

                cmd.Parameters.AddWithValue("@doctor",
                    cmbdoctor.SelectedValue);

                cmd.Parameters.AddWithValue("@date",
                    appdate.Value.Date);

                cmd.Parameters.AddWithValue("@time",
                    apptime.Value.ToString("HH:mm:ss"));

                cmd.Parameters.AddWithValue("@status",
                    cmbstatus.Text);

                cmd.Parameters.AddWithValue("@notes",
                    txtnote.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Appointment saved");

                LoadAppointments();
                btnclear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (appointmentID == 0)
            {
                MessageBox.Show("Please select an appointment to update.");
                return;
            }
            if (cmbpatient.SelectedValue == null || cmbpatient.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a patient.");
                return;
            }
            if (cmbdoctor.SelectedValue == null || cmbdoctor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a doctor.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbstatus.Text))
            {
                MessageBox.Show("Please select a status.");
                return;
            }
            if (appdate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Appointment date cannot be in the past.");
                return;
            }

            try
            {
                con.Open();

                string query =
                @"UPDATE appointments
          SET patient_id=@patient,
              doctor_id=@doctor,
              appointment_date=@date,
              appointment_time=@time,
              status=@status,
              notes=@notes
          WHERE appointment_id=@id";

                MySqlCommand cmd =
                    new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@patient",
                    cmbpatient.SelectedValue);
                cmd.Parameters.AddWithValue("@doctor",cmbdoctor.SelectedValue);

                cmd.Parameters.AddWithValue("@date",appdate.Value.Date);

                cmd.Parameters.AddWithValue("@time",apptime.Value.ToString("HH:mm:ss"));

                cmd.Parameters.AddWithValue("@status",cmbstatus.Text);

                cmd.Parameters.AddWithValue("@notes",txtnote.Text);

                cmd.Parameters.AddWithValue("@id",appointmentID);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Appointment Updated");

                LoadAppointments();
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
            if (appointmentID == 0)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            try
            {
                con.Open();
                string query = "DELETE FROM appointments WHERE appointment_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Appointment Deleted successfully");

                LoadAppointments();
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
            appointmentID = 0;
            cmbpatient.SelectedIndex = -1;
            cmbdoctor.SelectedIndex = -1;
            cmbstatus.SelectedIndex = -1;
            appdate.Value = DateTime.Today;
            apptime.Value = DateTime.Now;
            txtnote.Clear();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                                SELECT a.appointment_id,
                                       p.full_name AS Patient,
                                       d.full_name AS Doctor,
                                       a.appointment_date,
                                       a.appointment_time,
                                       a.status,
                                       a.notes
                                FROM appointments a
                                INNER JOIN patients p ON a.patient_id = p.patient_id
                                INNER JOIN doctors d ON a.doctor_id = d.doctor_id
                                WHERE p.full_name LIKE @search
                                   OR d.full_name LIKE @search
                                   OR a.status LIKE @search";
                MySqlCommand cmd =
                    new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@search", "%" + txtsearch.Text + "%");

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
    }
}
