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

namespace FoodiePointManagementSystem
{
    public partial class LogIN : Form
    {
        private Image defaultImage;
        private Image hoverImage;

        public LogIN()
        {
            InitializeComponent();

            defaultImage = Image.FromFile(@"Resources\FoodiePoint__2_-removebg-preview.png");
            hoverImage = Image.FromFile(@"Resources\HoverImg.png");

            pictureBox1.Image = defaultImage;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel1.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            txtPass.BackColor = SystemColors.Control;

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            lblShowPass.Visible = txtPass.Text.Length > 0;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1 .BackColor = SystemColors.Control;
            panel1.BackColor = SystemColors.Control;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar= true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = hoverImage;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = defaultImage;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT UserID, Role FROM Users WHERE UserName=@UserName AND Password=@Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["UserID"]);
                string role = dt.Rows[0]["Role"].ToString();

                MessageBox.Show($"Login Successful! Role: {role}");

                Form userForm = null;

                switch (role)
                {
                    case "Admin":
                        userForm = new AdminForm();
                        break;
                    case "Manager":
                        userForm = new ManagerMainForm(userId);
                        break;
                    case "Chef":
                        userForm = new ChefForm(userId);
                        break;
                    case "Reservation Coordinator":
                        userForm = new ReservationCoordinatorMainForm(userId);
                        break;
                    case "Customer":
                        userForm = new me();
                        break;
                }

                if (userForm != null)
                {
                    userForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
