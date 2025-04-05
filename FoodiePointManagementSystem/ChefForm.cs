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
    public partial class ChefForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-QLHJCNR\\SQLEXPRESS;Initial Catalog=FoodiePointDB;Integrated Security=True;";
        private int currentUserId;

        public ChefForm(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }

        private void ChefForm_Load(object sender, EventArgs e)

        {
            LoadOrders();
            LoadInventory();

            cmbOrderStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Completed" });
            cmbOrderStatus.SelectedIndex = 0; // Устанавливаем первый элемент по умолчанию
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
        }
        private void LoadOrders()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT OrderID, CustomerID, OrderDate, Status FROM Orders";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrders.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("注文情報の読み込みエラー: " + ex.Message);
                }
            }
        }

        private void LoadInventory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IngredientID, IngredientName, Quantity, Price FROM Inventory";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvInventory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ReadError of stock infomation: " + ex.Message);
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана строка в DataGridView
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order first", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID выбранного заказа
            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            // Получаем выбранный статус из ComboBox
            string newStatus = cmbOrderStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Please select a valid status", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Обновляем статус в базе данных
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", newStatus);
                        cmd.Parameters.AddWithValue("@OrderID", orderId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Order status updated to '{newStatus}' successfully",
                                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrders(); // Обновляем список заказов
                        }
                        else
                        {
                            MessageBox.Show("No orders were updated", "Warning",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update error: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // Устанавливаем текущий статус заказа в ComboBox
                string currentStatus = dgvOrders.SelectedRows[0].Cells["Status"].Value?.ToString();
                if (!string.IsNullOrEmpty(currentStatus))
                {
                    cmbOrderStatus.SelectedItem = currentStatus;
                }
            }
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            string ingredientName = txtIngredientName.Text.Trim();
            int quantity;
            decimal price;

            if (string.IsNullOrWhiteSpace(ingredientName) ||
                !int.TryParse(txtQuantity.Text.Trim(), out quantity) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out price))
            {
                MessageBox.Show("正しいデータを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Inventory (IngredientName, Quantity, Price) VALUES (@IngredientName, @Quantity, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("新しい食材を追加しました", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInventory();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("追加エラー: " + ex.Message);
                }
            }
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("更新する食材を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ingredientId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["IngredientID"].Value);
            int quantity;
            if (!int.TryParse(txtQuantity.Text.Trim(), out quantity))
            {
                MessageBox.Show("数量を正しく入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Inventory SET Quantity = @Quantity WHERE IngredientID = @IngredientID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@IngredientID", ingredientId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("在庫情報を更新しました", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInventory();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新エラー: " + ex.Message);
                }
            }
        }

        private void btnDeleteInventory_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("削除する食材を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ingredientId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["IngredientID"].Value);

            DialogResult confirm = MessageBox.Show("本当にこの食材を削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Inventory WHERE IngredientID = @IngredientID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@IngredientID", ingredientId);
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("食材を削除しました", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadInventory();
                            }
                            else
                            {
                                MessageBox.Show("削除に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("削除エラー: " + ex.Message);
                    }
                }
            }
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string newEmail = txtProfileEmail.Text.Trim();
            string newPassword = txtProfilePassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter both email and password", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = 3; // Это должно быть ID текущего пользователя

            try
            {
                // Хешируем пароль
                string hashedPassword = HashPassword(newPassword);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET Email = @Email, Password = @Password WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", newEmail);
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", this.currentUserId); // Используем переданный ID

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile updated successfully", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update profile", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            // Реализуйте хеширование пароля (например, используя BCrypt)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // ログインフォームを開く
                LogIN loginForm = new LogIN();
                loginForm.Show();

                // この画面を閉じる
                this.Close(); // または this.Hide();
            }
        }
    }
    }
    

