using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.OrderDetail
{
    public class OrderDetailVM
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
    }
}
