using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public class ReservationCoordinator : User
    {

        public List<Reservation> GetReservations(string status = null)
        {
            List<Reservation> reservations = new List<Reservation>();
            string query = @"SELECT r.ReservationID, r.CustomerID, u.Username AS CustomerName, 
                    r.HallID, h.HallName, r.EventType, r.StartDateTime, r.EndDateTime, 
                    r.PartySize, r.SpecialRequests, r.Status, r.CreatedDate, r.LastUpdated
                    FROM Reservations r
                    JOIN Users u ON r.CustomerID = u.UserID
                    JOIN Halls h ON r.HallID = h.HallID";

            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                query += " WHERE r.Status = @Status";
                SqlParameter[] parameters = { new SqlParameter("@Status", status) };
                var dt = DatabaseHelper.ExecuteQuery(query, parameters); // Изменено здесь

                foreach (DataRow row in dt.Rows)
                {
                    reservations.Add(MapDataRowToReservation(row));
                }
            }
            else
            {
                var dt = DatabaseHelper.ExecuteQuery(query); // Изменено здесь
                foreach (DataRow row in dt.Rows)
                {
                    reservations.Add(MapDataRowToReservation(row));
                }
            }

            return reservations;
        }

        private Reservation MapDataRowToReservation(DataRow row)
        {
            return new Reservation
            {
                ReservationID = Convert.ToInt32(row["ReservationID"]),
                CustomerID = Convert.ToInt32(row["CustomerID"]),
                CustomerName = row["CustomerName"].ToString(),
                HallID = Convert.ToInt32(row["HallID"]),
                HallName = row["HallName"].ToString(),
                EventType = row["EventType"].ToString(),
                StartDateTime = Convert.ToDateTime(row["StartDateTime"]),
                EndDateTime = Convert.ToDateTime(row["EndDateTime"]),
                PartySize = Convert.ToInt32(row["PartySize"]),
                SpecialRequests = row["SpecialRequests"].ToString(),
                Status = row["Status"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                LastUpdated = Convert.ToDateTime(row["LastUpdated"])
            };
        }

        public bool AddReservation(Reservation reservation)
        {
            string query = @"INSERT INTO Reservations (CustomerID, HallID, EventType, StartDateTime, 
                    EndDateTime, PartySize, SpecialRequests, Status)
                    VALUES (@CustomerID, @HallID, @EventType, @StartDateTime, 
                    @EndDateTime, @PartySize, @SpecialRequests, @Status)";

            SqlParameter[] parameters = {
        new SqlParameter("@CustomerID", reservation.CustomerID),
        new SqlParameter("@HallID", reservation.HallID),
        new SqlParameter("@EventType", reservation.EventType),
        new SqlParameter("@StartDateTime", reservation.StartDateTime),
        new SqlParameter("@EndDateTime", reservation.EndDateTime),
        new SqlParameter("@PartySize", reservation.PartySize),
        new SqlParameter("@SpecialRequests", reservation.SpecialRequests),
        new SqlParameter("@Status", reservation.Status)
    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool UpdateReservation(Reservation reservation)
        {
            string query = @"UPDATE Reservations SET 
                    HallID = @HallID,
                    EventType = @EventType,
                    StartDateTime = @StartDateTime,
                    EndDateTime = @EndDateTime,
                    PartySize = @PartySize,
                    SpecialRequests = @SpecialRequests,
                    Status = @Status,
                    LastUpdated = GETDATE()
                    WHERE ReservationID = @ReservationID";

            SqlParameter[] parameters = {
        new SqlParameter("@HallID", reservation.HallID),
        new SqlParameter("@EventType", reservation.EventType),
        new SqlParameter("@StartDateTime", reservation.StartDateTime),
        new SqlParameter("@EndDateTime", reservation.EndDateTime),
        new SqlParameter("@PartySize", reservation.PartySize),
        new SqlParameter("@SpecialRequests", reservation.SpecialRequests),
        new SqlParameter("@Status", reservation.Status),
        new SqlParameter("@ReservationID", reservation.ReservationID)
    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteReservation(int reservationId)
        {
            string query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
            SqlParameter[] parameters = { new SqlParameter("@ReservationID", reservationId) };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public List<Hall> GetAvailableHalls(DateTime startTime, DateTime endTime, int partySize)
        {
            List<Hall> halls = new List<Hall>();

            string query = @"SELECT h.HallID, h.HallName, h.Capacity, h.Description
                    FROM Halls h
                    WHERE h.Status = 'Available'
                    AND h.Capacity >= @PartySize
                    AND h.HallID NOT IN (
                        SELECT r.HallID 
                        FROM Reservations r
                        WHERE r.Status IN ('Pending', 'Confirmed')
                        AND (
                            (@StartTime BETWEEN r.StartDateTime AND r.EndDateTime)
                            OR (@EndTime BETWEEN r.StartDateTime AND r.EndDateTime)
                            OR (r.StartDateTime BETWEEN @StartTime AND @EndTime)
                            OR (r.EndDateTime BETWEEN @StartTime AND @EndTime)
                        )
                    )";

            SqlParameter[] parameters = {
        new SqlParameter("@StartTime", startTime),
        new SqlParameter("@EndTime", endTime),
        new SqlParameter("@PartySize", partySize)
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                halls.Add(new Hall
                {
                    HallID = Convert.ToInt32(row["HallID"]),
                    HallName = row["HallName"].ToString(),
                    Capacity = Convert.ToInt32(row["Capacity"]),
                    Description = row["Description"].ToString(),
                    Status = "Available"
                });
            }

            return halls;
        }

        public bool UpdateReservationStatus(int reservationId, string status)
        {
            string query = @"UPDATE Reservations SET 
                    Status = @Status,
                    LastUpdated = GETDATE()
                    WHERE ReservationID = @ReservationID";

            SqlParameter[] parameters = {
        new SqlParameter("@Status", status),
        new SqlParameter("@ReservationID", reservationId)
    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public List<ReservationMessage> GetMessages(int reservationId)
        {
            List<ReservationMessage> messages = new List<ReservationMessage>();

            string query = @"SELECT m.MessageID, m.ReservationID, m.SenderID, u.Username AS SenderName, 
                    m.MessageText, m.SentDateTime, m.IsRead
                    FROM ReservationMessages m
                    JOIN Users u ON m.SenderID = u.UserID
                    WHERE m.ReservationID = @ReservationID
                    ORDER BY m.SentDateTime ASC";

            SqlParameter[] parameters = { new SqlParameter("@ReservationID", reservationId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                messages.Add(new ReservationMessage
                {
                    MessageID = Convert.ToInt32(row["MessageID"]),
                    ReservationID = Convert.ToInt32(row["ReservationID"]),
                    SenderID = Convert.ToInt32(row["SenderID"]),
                    SenderName = row["SenderName"].ToString(),
                    MessageText = row["MessageText"].ToString(),
                    SentDateTime = Convert.ToDateTime(row["SentDateTime"]),
                    IsRead = Convert.ToBoolean(row["IsRead"])
                });
            }

            return messages;
        }

        public bool SendMessage(int reservationId, int senderId, string message)
        {
            string query = @"INSERT INTO ReservationMessages 
                    (ReservationID, SenderID, MessageText)
                    VALUES (@ReservationID, @SenderID, @MessageText)";

            SqlParameter[] parameters = {
        new SqlParameter("@ReservationID", reservationId),
        new SqlParameter("@SenderID", senderId),
        new SqlParameter("@MessageText", message)
    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public User GetUserById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                Username = row["Username"].ToString(),
                Password = row["Password"].ToString(),
                Email = row["Email"].ToString(),
                Role = row["Role"].ToString(),
              
            };
        }

        public bool UpdateUserProfile(User user)
        {
            string query = @"UPDATE Users SET 
                    Username = @Username,
                    Email = @Email,
                    Phone = @Phone
                    WHERE UserID = @UserID";

            SqlParameter[] parameters = {
        new SqlParameter("@Username", user.Username),
        new SqlParameter("@Email", user.Email),
        new SqlParameter("@Phone", user.Phone ?? (object)DBNull.Value),
        new SqlParameter("@UserID", user.UserID)
    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public DataTable GetCustomersFromDatabase(string query)
        {
            try
            {
                return DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public string GetReservationStatus(int reservationId)
        {
            string query = "SELECT Status FROM Reservations WHERE ReservationID = @ReservationID";
            SqlParameter[] parameters = { new SqlParameter("@ReservationID", reservationId) };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result?.ToString() ?? "Pending";
        }
    }
}
