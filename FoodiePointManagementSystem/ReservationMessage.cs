using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiePointManagementSystem
{
    public class ReservationMessage
    {
        public int MessageID { get; set; }
        public int ReservationID { get; set; }
        public int SenderID { get; set; }
        public string SenderName { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDateTime { get; set; }
        public bool IsRead { get; set; }
    }
}
