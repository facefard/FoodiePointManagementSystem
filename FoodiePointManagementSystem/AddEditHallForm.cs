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
    public partial class AddEditHallForm : Form
    {
        // Конструктор для добавления нового зала
        public AddEditHallForm()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0; // Устанавливаем "Available" по умолчанию

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        // Конструктор для редактирования существующего зала
        public AddEditHallForm(int hallId) : this()
        {
            HallID = hallId;
            LoadHallData();
        }

        public int HallID { get; private set; }
        public string HallName => txtHallName.Text.Trim();
        public int Capacity => (int)numCapacity.Value;
        public string Status => cboStatus.SelectedItem.ToString();

        private void LoadHallData()
        {
            string query = "SELECT HallName, Capacity, Status FROM Halls WHERE HallID = @HallID";
            SqlParameter[] parameters = { new SqlParameter("@HallID", HallID) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtHallName.Text = row["HallName"].ToString();
                numCapacity.Value = Convert.ToInt32(row["Capacity"]);
                cboStatus.SelectedItem = row["Status"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (HallID == 0)
                {
                    CreateNewHall();
                }
                else
                {
                    UpdateHall();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving hall: {ex.Message}", "Error",
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
            if (string.IsNullOrWhiteSpace(HallName))
            {
                MessageBox.Show("Please enter hall name", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select hall status", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CreateNewHall()
        {
            string query = @"INSERT INTO Halls (HallName, Capacity, Status) 
                           VALUES (@HallName, @Capacity, @Status)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@HallName", HallName),
                new SqlParameter("@Capacity", Capacity),
                new SqlParameter("@Status", Status)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private void UpdateHall()
        {
            string query = @"UPDATE Halls SET 
                           HallName = @HallName, 
                           Capacity = @Capacity, 
                           Status = @Status
                           WHERE HallID = @HallID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@HallName", HallName),
                new SqlParameter("@Capacity", Capacity),
                new SqlParameter("@Status", Status),
                new SqlParameter("@HallID", HallID)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
