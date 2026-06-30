using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter username and password.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRole = "";

            if (rbadmin.Checked)
                selectedRole = "Admin";
            else if (rbdoctor.Checked)
                selectedRole = "Doctor";
            else if (rbrec.Checked)
                selectedRole = "Reception";
            else
            {
                MessageBox.Show("Please select a role.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = "server=localhost;database=dental_system;user=root;password=;";

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT *
                             FROM users
                             WHERE Username=@username
                             AND Password=@password
                             AND Role=@role
                             AND Status='Active'";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", selectedRole);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        CurrentUser.user_id = Convert.ToInt32(dr["user_id"]);
                        CurrentUser.full_name = dr["full_name"].ToString();
                        CurrentUser.username = dr["username"].ToString();
                        CurrentUser.role = dr["role"].ToString();

                        Dashboard dash = new Dashboard();
                        dash.Show();
                        this.Hide();
                        MessageBox.Show("Welcome " + selectedRole + "!",
                            "Login Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username, password or role.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        txtUsername.Clear();
                        txtPassword.Clear();

                        txtUsername.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';

            rbadmin.Checked = true;

            txtUsername.Focus();
        }
        
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
