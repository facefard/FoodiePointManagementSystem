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
    public partial class UpdateManagerProfileForm : Form
    {
        private readonly int _userId;

        public UpdateManagerProfileForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserData();
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; private set; }

        private void LoadUserData()
        {
            string query = "SELECT UserName, Email FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", _userId) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                txtUsername.Text = dt.Rows[0]["UserName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Username and email cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtNewPassword.Text) &&
                txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.UserName = txtUsername.Text.Trim();
            this.Email = txtEmail.Text.Trim();
            this.NewPassword = txtNewPassword.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
