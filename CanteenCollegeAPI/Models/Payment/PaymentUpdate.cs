using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.Payment
{
    public class PaymentUpdate
    {
        public int ID { get; set; }
        public int? StaffId { get; set; }

        public int? OrderId { get; set; }
    }
}
