using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class feedback : Form
    {
        // Update with your SQL Server connection details
        private string connectionString = "Data Source=DESKTOP-8OFLI40\\SQLEXPRESS;Initial Catalog=my,db;Integrated Security=True";

        public feedback()
        {
            InitializeComponent();
        }

        // Submit Feedback
        private void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFeedbackUsername.Text) || string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Please fill in all feedback fields before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Feedback (CustomerUsername, Comment) VALUES (@username, @comment)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtFeedbackUsername.Text);
                    cmd.Parameters.AddWithValue("@comment", txtComment.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFeedbackUsername.Clear();
                        txtComment.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Submit Reservation
        // Submit Reservation (Renamed)
        private void btnConfirmReservation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReservationUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtTableNumber.Text))
            {
                MessageBox.Show("Please fill in all reservation fields before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTableNumber.Text, out int tableNumber))
            {
                MessageBox.Show("Please enter a valid table number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reservation (CustomerUsername, PhoneNumber, TableNumber, ReservationDate) VALUES (@username, @phone, @table, @date)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtReservationUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@table", tableNumber);
                    cmd.Parameters.AddWithValue("@date", dtpReservationDate.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear fields
                        txtReservationUsername.Clear();
                        txtPhoneNumber.Clear();
                        txtTableNumber.Clear();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("Database Error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Ensure event handlers exist to prevent missing reference errors
        private void label9_Click(object sender, EventArgs e) { }
        private void feedback_Load(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            me meForm = new me();
            meForm.Show();
            this.Hide();

        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
