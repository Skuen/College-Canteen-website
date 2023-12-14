using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.Payment
{
    public class PaymentInsert
    {
        public int? StaffId { get; set; }

        public int? OrderId { get; set; }
    }
}
