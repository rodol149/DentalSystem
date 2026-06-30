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
    public partial class Dashboard : Form
    {
        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        public Dashboard()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }

        private Form activeForm = null;

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            label1.Text = childForm.Text; // Dynamic dashboard header title
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnpat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Patient());
        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Doctors());
        }

        private void btnappo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new appointments());
        }

        private void btntre_Click(object sender, EventArgs e)
        {
            OpenChildForm(new treatment());
        }

        private void btnservice_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Service());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ApplyPermissions();
            // Show home stats by default
            OpenChildForm(new DashboardHome());
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardHome());
        }
        private void ApplyPermissions()
        {
            switch (CurrentUser.role)
            {
                case "Admin":

                    break;

                case "Reception":

                    btnuser.Visible = false;
                    btnreports.Visible = false;
                    break;

                case "Doctor":

                    btnuser.Visible = false;
                    btnreports.Visible = false;
                    btnpay.Visible = false;
                    btnservice.Visible = false;
                    break;
            }
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            OpenChildForm(new payments());
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reports());
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new User());
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();

                this.Close();
            }
        }
    
    }
    
}
