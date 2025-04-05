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
    public partial class AddEditMenuItemForm : Form
    {
        public AddEditMenuItemForm(int menuId = 0)
        {
            InitializeComponent();
            LoadCategories();
            numPrice.Value = 10.00m;


            if (menuId > 0)
            {
                MenuID = menuId;
                LoadMenuItemData();
            }
        }

        public int MenuID { get; private set; }
        public string ItemName => txtItemName.Text.Trim();
        public string Category => cboCategory.SelectedItem?.ToString();
        public decimal Price => numPrice.Value;
        public bool IsAvailable => chkAvailable.Checked;

        private void LoadCategories()
        {
            string query = "SELECT DISTINCT Category FROM Menu";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            cboCategory.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cboCategory.Items.Add(row["Category"]);
            }

            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
        }

        private void LoadMenuItemData()
        {
            string query = "SELECT ItemName, Category, Price, Availability FROM Menu WHERE MenuID = @MenuID";
            SqlParameter[] parameters = { new SqlParameter("@MenuID", MenuID) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtItemName.Text = row["ItemName"].ToString();
                cboCategory.SelectedItem = row["Category"].ToString();
                numPrice.Value = Convert.ToDecimal(row["Price"]);
                chkAvailable.Checked = Convert.ToBoolean(row["Availability"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                if (MenuID == 0)
                {
                    CreateMenuItem();
                }
                else
                {
                    UpdateMenuItem();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving menu item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                MessageBox.Show("Please enter item name", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Price <= 0)
            {
                MessageBox.Show("Price must be greater than 0", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CreateMenuItem()
        {
            string query = @"INSERT INTO Menu (ItemName, Category, Price, Availability) 
                           VALUES (@ItemName, @Category, @Price, @Availability)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ItemName", ItemName),
                new SqlParameter("@Category", Category),
                new SqlParameter("@Price", Price),
                new SqlParameter("@Availability", IsAvailable)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private void UpdateMenuItem()
        {
            string query = @"UPDATE Menu SET 
                           ItemName = @ItemName, 
                           Category = @Category, 
                           Price = @Price, 
                           Availability = @Availability
                           WHERE MenuID = @MenuID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ItemName", ItemName),
                new SqlParameter("@Category", Category),
                new SqlParameter("@Price", Price),
                new SqlParameter("@Availability", IsAvailable),
                new SqlParameter("@MenuID", MenuID)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
