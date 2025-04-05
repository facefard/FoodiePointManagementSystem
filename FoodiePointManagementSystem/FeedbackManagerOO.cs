using System;
using System.Data;
using System.Data.SqlClient;

namespace FoodiePointManagementSystem
{
    public class FeedbackManagerOO
    {
        private readonly string connectionString;

        public FeedbackManagerOO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetFeedback()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT FeedbackID, CustomerName, 
                               Comments AS Message, Rating, 
                               FORMAT(FeedbackDate, 'yyyy-MM-dd') AS Date
                               FROM Feedback";

                new SqlDataAdapter(query, connection).Fill(table);
            }

            return table;
        }
    }
}
