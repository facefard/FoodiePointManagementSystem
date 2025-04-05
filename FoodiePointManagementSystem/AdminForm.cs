﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FoodiePointManagementSystem
{
    public partial class AdminForm : Form
    {
        string connectionString = "Data Source=DESKTOP-QLHJCNR\\SQLEXPRESS;Initial Catalog=FoodiePointDB;Integrated Security=True;";

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)

        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Manager");
            cmbRole.Items.Add("Chef");
            cmbRole.Items.Add("Reservation Coordinator");
            cmbRole.Items.Add("Customer");

            cmbRole.SelectedIndex = 0;


            LoadUserData();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                LogIN loginForm = new LogIN();
                loginForm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in both Username and Email.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users (UserName, Email, Role) VALUES (@UserName, @Email, @Role)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", role);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "User added successfully." : "Failed to add user.",
                                    "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadUserData();
        }

        private void LoadUserData()
        {
            string connectionString = "Data Source=DESKTOP-QLHJCNR\\SQLEXPRESS;Initial Catalog=FoodiePointDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserID, UserName, Email, Role FROM Users"; // 必要なカラムを指定
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvUser.DataSource = dataTable; // DataGridView にデータをバインド
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUser.Rows[e.RowIndex].Cells["UserName"].Value != null)
            {
                txtUsername.Text = dgvUser.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                txtEmail.Text = dgvUser.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string roleValue = dgvUser.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                if (cmbRole.Items.Contains(roleValue))
                {
                    cmbRole.SelectedItem = roleValue;
                }
                else
                {
                    cmbRole.SelectedIndex = 0;
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user row in the table to delete.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["UserID"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                                                  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Users WHERE UserID = @UserID";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "User deleted successfully." : "User deletion failed.",
                                        "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadUserData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user row in the table to update.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["UserID"].Value);
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in both Username and Email.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE Users 
                                     SET UserName = @UserName, Email = @Email, Role = @Role 
                                     WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "User updated successfully." : "User update failed.",
                                    "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadUserData();
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnViewSalesReport_Click(object sender, EventArgs e)
        {
            string monthInput = Interaction.InputBox("Enter month (1-12):", "Sales Report", "1");
            if (!int.TryParse(monthInput, out int month))
            {
                MessageBox.Show("Invalid month value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string category = Interaction.InputBox("Enter food category (or 'Any' for all):", "Sales Report", "Any");
            string chef = Interaction.InputBox("Enter chef name (or leave blank for any):", "Sales Report", "");

            // Use the SalesReportManager object to get the report.
            SalesReportManager reportManager = new SalesReportManager(connectionString);
            decimal totalSales = reportManager.GetTotalSales(month, category, chef);

            MessageBox.Show($"Total Sales for Month {month}\nCategory: {category}\nChef: {chef}\nTotal Sales: ${totalSales}",
                            "Sales Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnViewFeedback_Click(object sender, EventArgs e)
        {
            FeedbackManagerOO feedbackManager = new FeedbackManagerOO(connectionString);
            DataTable feedbackTable = feedbackManager.GetFeedback();
            string feedbackStr = "Customer Feedback:\n";
            foreach (DataRow row in feedbackTable.Rows)
            {
                feedbackStr += $"ID: {row["FeedbackID"]} | {row["CustomerName"]}: {row["Message"]}\n";
            }
            MessageBox.Show(feedbackStr, "Customer Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
