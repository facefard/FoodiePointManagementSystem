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
    public partial class AdminForm : Form
    {
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
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void LoadUserData()
        {
            string connectionString = "Server=LENO\\SQLEXPRESS;Database=FoodiePointDB;Integrated Security=True;";

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
                    MessageBox.Show("データの読み込みに失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
