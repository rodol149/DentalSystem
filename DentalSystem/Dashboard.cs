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

        private void btnpat_Click(object sender, EventArgs e)
        {
            // meshaan ha hilmaamin
            Patient patient = new Patient();
            patient.Show();

        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            Doctors doc = new Doctors();
            doc.Show();
        }

        private void btnappo_Click(object sender, EventArgs e)
        {
            appointments app=new appointments();
            app.Show();
        }

        private void btntre_Click(object sender, EventArgs e)
        {
            treatment tr = new treatment();
            tr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service sr=new Service();
            sr.Show();
        }

         private void Dashboard_Load(object sender, EventArgs e)
        {
            //lblUser.Text = CurrentUser.FullName;
            //lblRole.Text = CurrentUser.Role;

            ApplyPermissions();
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
            payments bay = new payments ();
            bay.Show();
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
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
