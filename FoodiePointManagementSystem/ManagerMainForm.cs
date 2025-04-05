using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class ManagerMainForm : Form
    {
        private int currentUserId;

        public ManagerMainForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;

            // Подключение обработчиков событий
            btnAddMenuItem.Click += btnAddMenuItem_Click;
            btnEditMenuItem.Click += btnEditMenuItem_Click;
            btnDeleteMenuItem.Click += btnDeleteMenuItem_Click;
            btnAddHall.Click += btnAddHall_Click;
            btnEditHall.Click += btnEditHall_Click;
            btnDeleteHall.Click += btnDeleteHall_Click;
            btnViewReports.Click += btnViewReports_Click;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            btnLogout.Click += btnLogout_Click;
            cboMenuCategoryFilter.SelectedIndexChanged += cboCategory_SelectedIndexChanged;

            LoadUserData();
            LoadMenuCategories();
            LoadMenuItems();
            LoadHalls();
        }

        // 1. Методы загрузки данных
        private void LoadUserData()
        {
            string query = "SELECT UserName FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", currentUserId) };

            DataTable dt = DBHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                lblWelcome.Text = $"Welcome, {dt.Rows[0]["UserName"]}";
        }

        private void LoadMenuCategories()
        {
            cboMenuCategoryFilter.Items.Add("All");
            DataTable categories = DBHelper.ExecuteQuery("SELECT DISTINCT Category FROM Menu");
            foreach (DataRow row in categories.Rows)
                cboMenuCategoryFilter.Items.Add(row["Category"]);
            cboMenuCategoryFilter.SelectedIndex = 0;
        }

        private void LoadMenuItems(string category = null)
        {
            string query = "SELECT * FROM Menu";
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                query += " WHERE Category = @Category";
                SqlParameter[] parameters = { new SqlParameter("@Category", category) };
                dgvMenuItems.DataSource = DBHelper.ExecuteQuery(query, parameters);
            }
            else
            {
                dgvMenuItems.DataSource = DBHelper.ExecuteQuery(query);
            }
        }

        private void LoadHalls()
        {
            dgvHalls.DataSource = DBHelper.ExecuteQuery("SELECT * FROM Halls");
        }

        // 2. Обработчики событий (используют ваши существующие контролы)
        private void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditMenuItemForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadMenuCategories(); // Обновляем фильтр
                    LoadMenuItems();     // Обновляем список блюд
                }
            }
        }

        private void btnEditMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a menu item to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int menuId = (int)dgvMenuItems.SelectedRows[0].Cells["MenuID"].Value;
            using (var form = new AddEditMenuItemForm(menuId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string query = @"UPDATE Menu SET 
                          ItemName = @ItemName, 
                          Category = @Category, 
                          Price = @Price, 
                          Availability = @Availability
                          WHERE MenuID = @MenuID";

                    SqlParameter[] parameters =
                    {
                new SqlParameter("@ItemName", form.ItemName),
                new SqlParameter("@Category", form.Category),
                new SqlParameter("@Price", form.Price),
                new SqlParameter("@Availability", form.IsAvailable),
                new SqlParameter("@MenuID", menuId)
            };

                    if (DBHelper.ExecuteNonQuery(query, parameters) > 0)
                    {
                        LoadMenuItems();
                        LoadMenuCategories(); // Обновляем фильтр на случай изменения категории
                    }
                }
            }
        }

        private void btnDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.SelectedRows.Count == 0) return;

            int menuId = (int)dgvMenuItems.SelectedRows[0].Cells["MenuID"].Value;
            string confirmMsg = $"Delete {dgvMenuItems.SelectedRows[0].Cells["ItemName"].Value}?";

            if (MessageBox.Show(confirmMsg, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Menu WHERE MenuID = @ID";
                SqlParameter[] parameters = { new SqlParameter("@ID", menuId) };

                if (DBHelper.ExecuteNonQuery(query, parameters) > 0)
                    LoadMenuItems();
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuItems(cboMenuCategoryFilter.SelectedItem?.ToString());
        }

        // 3. Аналогичные методы для работы с залами
        private void btnAddHall_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditHallForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadHalls();
                }
            }
        }

        private void btnEditHall_Click(object sender, EventArgs e)
        {
            if (dgvHalls.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a hall to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int hallId = (int)dgvHalls.SelectedRows[0].Cells["HallID"].Value;
            using (var form = new AddEditHallForm(hallId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string query = @"UPDATE Halls SET 
                          HallName = @HallName, 
                          Capacity = @Capacity, 
                          Status = @Status
                          WHERE HallID = @HallID";

                    SqlParameter[] parameters =
                    {
                new SqlParameter("@HallName", form.HallName),
                new SqlParameter("@Capacity", form.Capacity),
                new SqlParameter("@Status", form.Status),
                new SqlParameter("@HallID", hallId)
            };

                    if (DBHelper.ExecuteNonQuery(query, parameters) > 0)
                    {
                        LoadHalls();
                    }
                }
            }
        }

        private void btnDeleteHall_Click(object sender, EventArgs e)
        {
            if (dgvHalls.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a hall to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int hallId = (int)dgvHalls.SelectedRows[0].Cells["HallID"].Value;
            string hallName = dgvHalls.SelectedRows[0].Cells["HallName"].Value.ToString();

            if (MessageBox.Show($"Delete hall '{hallName}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Проверяем, есть ли связанные бронирования
                    string checkQuery = "SELECT COUNT(*) FROM Reservations WHERE HallID = @HallID";
                    SqlParameter[] checkParams = { new SqlParameter("@HallID", hallId) };
                    int reservationCount = (int)DBHelper.ExecuteScalar(checkQuery, checkParams);

                    if (reservationCount > 0)
                    {
                        MessageBox.Show("Cannot delete - there are reservations for this hall.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string deleteQuery = "DELETE FROM Halls WHERE HallID = @HallID";
                    SqlParameter[] deleteParams = { new SqlParameter("@HallID", hallId) };

                    if (DBHelper.ExecuteNonQuery(deleteQuery, deleteParams) > 0)
                    {
                        MessageBox.Show("Hall deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHalls();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting hall: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            using (var form = new UpdateManagerProfileForm(currentUserId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string query = @"UPDATE Users SET 
                          UserName = @UserName, 
                          Email = @Email
                          WHERE UserID = @UserID";

                    SqlParameter[] parameters =
                    {
                new SqlParameter("@UserName", form.UserName),
                new SqlParameter("@Email", form.Email),
                new SqlParameter("@UserID", currentUserId)
            };

                    if (DBHelper.ExecuteNonQuery(query, parameters) > 0)
                    {
                        MessageBox.Show("Profile updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData(); // Обновляем приветствие
                    }
                }
            }
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {

            new ReportForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort; // Можно использовать для определения выхода
                this.Close();
                LogIN loginForm = new LogIN();
                loginForm.Show();
            }
        }
    }
}