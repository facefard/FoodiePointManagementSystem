using System;
using System.Data.SqlClient;

public class CustomerStatusChecker
{
    private string connectionString = "Data Source=DESKTOP-8OFLI40\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True";

    public CustomerStatusChecker(string dbConnectionString)
    {
        this.connectionString = dbConnectionString;
    }

    public (string orderStatus, string reservationStatus) GetStatus(string customerName)
    {
        string orderStatus = "No order found.";
        string reservationStatus = "No reservation found.";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get Order Status
                using (SqlCommand cmd = new SqlCommand("SELECT OrderStatus FROM Orders WHERE CustomerName = @CustomerName", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    var result = cmd.ExecuteScalar();

                    // Check if the result is null or DBNull
                    if (result != null && result != DBNull.Value)
                    {
                        orderStatus = $"Order Status: {result.ToString()}";
                    }
                }

                // Get Reservation Status
                using (SqlCommand cmd = new SqlCommand("SELECT ReservationStatus FROM Reservation WHERE CustomerName = @CustomerName", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    var result = cmd.ExecuteScalar();

                    // Check if the result is null or DBNull
                    if (result != null && result != DBNull.Value)
                    {
                        reservationStatus = $"Reservation Status: {result.ToString()}";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // If an error occurs, log or display the error
            Console.WriteLine("Error: " + ex.Message);
        }

        return (orderStatus, reservationStatus);
    }
}
