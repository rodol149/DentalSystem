using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DentalSystem
{
    public partial class DashboardHome : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;

        // Color palette matching the sidebar design
        private readonly Color NavyBlue   = Color.FromArgb(30, 58, 95);
        private readonly Color AccentBlue = Color.FromArgb(41, 128, 185);
        private readonly Color TealGreen  = Color.FromArgb(22, 160, 133);
        private readonly Color Orange     = Color.FromArgb(211, 84, 0);
        private readonly Color Purple     = Color.FromArgb(142, 68, 173);
        private readonly Color LightBg    = Color.FromArgb(245, 247, 250);
        private readonly Color TextDark   = Color.FromArgb(44, 62, 80);
        private readonly Color TextGray   = Color.FromArgb(127, 140, 141);

        public DashboardHome()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }

        private void DashboardHome_Load(object sender, EventArgs e)
        {
            this.BackColor = LightBg;
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();

                // Total Patients
                var patientsCount = GetScalar("SELECT COUNT(*) FROM patients");
                UpdateStatCard(pnlPatients, lblPatCount, patientsCount);

                // Total Doctors
                var doctorsCount = GetScalar("SELECT COUNT(*) FROM doctors WHERE status='Active'");
                UpdateStatCard(pnlDoctors, lblDocCount, doctorsCount);

                // Today's Appointments
                var apptCount = GetScalar("SELECT COUNT(*) FROM appointments WHERE DATE(appointment_date) = CURDATE()");
                UpdateStatCard(pnlAppointments, lblApptCount, apptCount);

                // Total Treatments
                var treatCount = GetScalar("SELECT COUNT(*) FROM treatments");
                UpdateStatCard(pnlTreatments, lblTreatCount, treatCount);

                // Total Revenue
                var revenue = GetScalar("SELECT IFNULL(SUM(amount),0) FROM payments");
                lblRevenue.Text = "$" + string.Format("{0:N0}", revenue);

                // Pending Invoices
                var pending = GetScalar("SELECT COUNT(*) FROM invoices WHERE status='Pending'");
                lblPendingInv.Text = pending.ToString();

                // Unpaid count
                var unpaid = GetScalar("SELECT COUNT(*) FROM invoices WHERE status='Unpaid'");
                lblUnpaidInv.Text = unpaid.ToString();

                // Recent appointments (last 5)
                LoadRecentAppointments();
            }
            catch
            {
                // DB might not be available — show zeros
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private long GetScalar(string query)
        {
            using (var cmd = new MySqlCommand(query, con))
            {
                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToInt64(result);
            }
        }

        private void UpdateStatCard(Panel card, Label countLabel, long value)
        {
            countLabel.Text = value.ToString("N0");
        }

        private void LoadRecentAppointments()
        {
            try
            {
                string query = @"SELECT p.full_name AS Patient, d.full_name AS Doctor, 
                                        a.appointment_date AS Date, a.status AS Status
                                 FROM appointments a
                                 INNER JOIN patients p ON a.patient_id = p.patient_id
                                 INNER JOIN doctors  d ON a.doctor_id  = d.doctor_id
                                 ORDER BY a.appointment_date DESC LIMIT 8";

                var da = new MySqlDataAdapter(query, con);
                var dt = new DataTable();
                da.Fill(dt);
                dgvRecent.DataSource = dt;
            }
            catch { /* no data */ }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        // ── Rounded panel paint helper ─────────────────────────────────────
        private void StatPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(pnl.BackColor))
            {
                var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                g.FillRoundedRectangle(brush, rect, 14);
            }
        }
    }

    // Extension method for rounded rectangles
    internal static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }
}
