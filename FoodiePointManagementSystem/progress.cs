using System;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class progressForm : Form  // Make sure this matches Designer.cs
    {
        public progressForm()
        {
            InitializeComponent();
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();

            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Please enter a customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbConnectionString = "Data Source=DESKTOP-8OFLI40\\SQLEXPRESS;Initial Catalog=my,db;Integrated Security=True";
            CustomerStatusChecker statusChecker = new CustomerStatusChecker(dbConnectionString);
            var (orderStatus, reservationStatus) = statusChecker.GetStatus(customerName);

            lblOrderStatus.Text = $"Order Status: {orderStatus}";
            lblReservationStatus.Text = $"Reservation Status: {reservationStatus}";
        }

        private void progressForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer meForm = new Customer();
            meForm.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Customer meForm = new Customer();
           meForm.Show();
            this.Hide();


        }
    }
}