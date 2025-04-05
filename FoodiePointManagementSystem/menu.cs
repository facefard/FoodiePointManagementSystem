using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class menu : Form
    {
        string connectionString = "Data Source=DESKTOP-QLHJCNR\\SQLEXPRESS;Initial Catalog=FoodiePointDB;Integrated Security=True;";
        decimal totalPrice = 0;

        public menu()
        {
            InitializeComponent();
            LoadMenu();
            InitializeCartListView();
        }

        private void InitializeCartListView()
        {
            cartListView.View = View.Details;
            cartListView.Columns.Add("Item", 150);
            cartListView.Columns.Add("Price", 70, HorizontalAlignment.Right);
            cartListView.Columns.Add("Qty", 50, HorizontalAlignment.Right);
            cartListView.Columns.Add("Total", 80, HorizontalAlignment.Right);
        }

        private void LoadMenu()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ItemName AS Name, Price, Availability FROM Menu WHERE Availability = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = ((DataTable)dataGridView1.DataSource).Rows[e.RowIndex];
                string itemName = row["Name"].ToString();
                decimal itemPrice = Convert.ToDecimal(row["Price"]);

                // Check if item exists in cart
                ListViewItem existingItem = null;
                foreach (ListViewItem item in cartListView.Items)
                {
                    if (item.Text == itemName)
                    {
                        existingItem = item;
                        break;
                    }
                }

                if (existingItem != null)
                {
                    int qty = int.Parse(existingItem.SubItems[2].Text) + 1;
                    existingItem.SubItems[2].Text = qty.ToString();
                    existingItem.SubItems[3].Text = (qty * itemPrice).ToString("C");
                }
                else
                {
                    ListViewItem newItem = new ListViewItem(itemName);
                    newItem.SubItems.Add(itemPrice.ToString("C"));
                    newItem.SubItems.Add("1");
                    newItem.SubItems.Add(itemPrice.ToString("C"));
                    cartListView.Items.Add(newItem);
                }

                UpdateTotalPrice();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartListView.Items.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter customer name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 1. Create the order
                    string insertOrder = @"INSERT INTO Orders (CustomerID, OrderDate, Status, TotalPrice) 
                                         VALUES (@CustomerID, GETDATE(), 'Pending', @TotalPrice);
                                         SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdOrder = new SqlCommand(insertOrder, con);
                    cmdOrder.Parameters.AddWithValue("@CustomerID", GetOrCreateCustomer(txtCustomerName.Text));
                    cmdOrder.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                    // 2. Add order details
                    foreach (ListViewItem item in cartListView.Items)
                    {
                        string insertDetail = @"INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal)
                                              VALUES (@OrderID, 
                                                     (SELECT MenuID FROM Menu WHERE ItemName = @ItemName), 
                                                     @Quantity, 
                                                     @Subtotal)";

                        SqlCommand cmdDetail = new SqlCommand(insertDetail, con);
                        cmdDetail.Parameters.AddWithValue("@OrderID", orderId);
                        cmdDetail.Parameters.AddWithValue("@ItemName", item.Text);
                        cmdDetail.Parameters.AddWithValue("@Quantity", int.Parse(item.SubItems[2].Text));
                        cmdDetail.Parameters.AddWithValue("@Subtotal",
                            decimal.Parse(item.SubItems[3].Text, System.Globalization.NumberStyles.Currency));

                        cmdDetail.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Order #{orderId} created successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear cart
                    cartListView.Items.Clear();
                    totalPrice = 0;
                    lblTotalPrice.Text = "Total: $0.00";
                    txtCustomerName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetOrCreateCustomer(string customerName)
        {
            // Check if customer exists
            string findCustomer = "SELECT UserID FROM Users WHERE UserName = @Name AND Role = 'Customer'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(findCustomer, con);
                cmd.Parameters.AddWithValue("@Name", customerName);
                object result = cmd.ExecuteScalar();

                if (result != null) return Convert.ToInt32(result);

                // Create new customer if not exists
                string insertCustomer = @"INSERT INTO Users (UserName, Email, Password, Role) 
                                        VALUES (@Name, @Email, 'DefaultPassword123', 'Customer');
                                        SELECT SCOPE_IDENTITY();";

                cmd.CommandText = insertCustomer;
                cmd.Parameters.AddWithValue("@Email", $"{customerName.Replace(" ", "")}@foodiepoint.com");

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void UpdateTotalPrice()
        {
            totalPrice = 0;
            foreach (ListViewItem item in cartListView.Items)
            {
                totalPrice += decimal.Parse(item.SubItems[3].Text, System.Globalization.NumberStyles.Currency);
            }
            lblTotalPrice.Text = $"Total: {totalPrice:C}";
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cartListView.Items.Clear();
            totalPrice = 0;
            lblTotalPrice.Text = "Total: $0.00";
        }
    }
}
