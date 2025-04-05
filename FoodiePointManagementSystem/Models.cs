using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiePointManagementSystem
{

    public class MenuItem
    {
        public int MenuID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
    }
}