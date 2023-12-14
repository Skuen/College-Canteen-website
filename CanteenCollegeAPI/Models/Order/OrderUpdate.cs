using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.Order
{
    public class OrderUpdate
    {
        public int ID { get; set; }

        public int? Status { get; set; }
    }
}
