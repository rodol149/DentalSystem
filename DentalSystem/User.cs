using MySql.Data.MySqlClient;
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
    public partial class User : Form
    {

        string connString = "server=localhost;database=dental_system;user=root;password=;";
        MySqlConnection con;
        public User()
        {
            InitializeComponent();
            con = new MySqlConnection(connString);
        }

        private void User_Load(object sender, EventArgs e)
        {
            cmbrole.Items.Add("Admin");
            cmbrole.Items.Add("Doctor");
            cmbrole.Items.Add("Reception");

            cmbstatus.Items.Add("Active");
            cmbstatus.Items.Add("Inactive");

            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string query = @"SELECT
                        user_id AS 'ID',
                        full_name AS 'Full Name',
                        username AS 'Username',
                        role AS 'Role',
                        status AS 'Status',
                        created_at AS 'Created'
                        FROM users";

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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string query = @"INSERT INTO users
                                    (full_name,username,password,role,status,created_at)
                                    VALUES
                                    (@name,@user,@pass,@role,@status,NOW())";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", txtfullname.Text);
                cmd.Parameters.AddWithValue("@user", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                cmd.Parameters.AddWithValue("@role", cmbrole.Text);
                cmd.Parameters.AddWithValue("@status", cmbstatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Saved Successfully");

                LoadUsers();

                ClearData();
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string query = "DELETE FROM users WHERE user_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Deleted");

                LoadUsers();

                ClearData();
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
       try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();

                string query = @"SELECT
                                user_id AS 'ID',
                                full_name AS 'Full Name',
                                username AS 'Username',
                                role,
                                status,
                                created_at

                                FROM users

                                WHERE full_name LIKE @search
                                OR username LIKE @search";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtsearch.Text + "%");

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtfullname.Text = dataGridView1.CurrentRow.Cells["Full Name"].Value.ToString();
            txtusername.Text = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();
            cmbrole.Text = dataGridView1.CurrentRow.Cells["Role"].Value.ToString();
            cmbstatus.Text = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtfullname.Clear();
            txtusername.Clear();
            txtpassword.Clear();

            cmbrole.SelectedIndex = -1;
            cmbstatus.SelectedIndex = -1;

            txtfullname.Focus();
        }
        private void ClearData()
        {
            txtfullname.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            cmbrole.SelectedIndex = -1;
            cmbstatus.SelectedIndex = -1;
            txtfullname.Focus();
        }

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            try
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string query = @"UPDATE users SET

                                        full_name=@name,
                                        username=@user,
                                        password=@pass,
                                        role=@role,
                                        status=@status

                                        WHERE user_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", txtfullname.Text);
                cmd.Parameters.AddWithValue("@user", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                cmd.Parameters.AddWithValue("@role", cmbrole.Text);
                cmd.Parameters.AddWithValue("@status", cmbstatus.Text);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully");

                LoadUsers();

                ClearData();
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
        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    ClearData();
        //}
    }
    
    

}

