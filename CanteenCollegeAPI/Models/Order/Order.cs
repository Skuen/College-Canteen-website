using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.Order
{
    public class Order
    {
        public int ID { get; set; }

        public int? UserId { get; set; }

        public int? Status { get; set; }

        public DateTime? OrderDate { get; set; }

    }
}
