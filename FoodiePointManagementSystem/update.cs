using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class update : Form
    {
        private string connectionString = "Data Source=DESKTOP-8OFLI40\\SQLEXPRESS;Initial Catalog=my,db;Integrated Security=True";

        public update()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            // Do nothing or add code here
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Do nothing or add logic here
        }
        private void update_Load(object sender, EventArgs e)
        {
            // This method will be called when the form loads
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Do nothing or add code here
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string oldUsername = textBox1.Text.Trim().ToLower();
            string newUsername = txtNewUsername.Text.Trim().ToLower();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldUsername) || string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if the old username exists (case-insensitive)
                string checkQuery = "SELECT COUNT(*) FROM login WHERE LOWER(username) = @oldUsername";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@oldUsername", oldUsername);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount == 0)
                    {
                        MessageBox.Show("The entered username does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Update username and password
                string updateQuery = "UPDATE login SET username = @newUsername, password = @newPassword WHERE LOWER(username) = @oldUsername";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@newUsername", newUsername);
                    updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                    updateCmd.Parameters.AddWithValue("@oldUsername", oldUsername);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            me meForm = new me();
            meForm.Show();
            this.Hide();

        }
    }
}