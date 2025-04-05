using System;
using System.Data;
using System.Data.SqlClient;

namespace FoodiePointManagementSystem
{
    public class SalesReportManager
    {
        private readonly string connectionString;

        public SalesReportManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public decimal GetTotalSales(int month, string category, string chef)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT SUM(TotalAmount) 
                               FROM Sales 
                               WHERE MONTH(SaleDate) = @Month 
                               AND (@Category = 'Any' OR Category = @Category)
                               AND (@Chef = '' OR Chef LIKE '%' + @Chef + '%')";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Chef", string.IsNullOrEmpty(chef) ? "" : chef);

                connection.Open();
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
        }
    }
}
