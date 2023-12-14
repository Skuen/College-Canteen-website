using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.Dishes
{
    public class DishesUpdate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public IFormFile coverImage { get; set; }

        public float? Price { get; set; }

        public int? CategoryID { get; set; }

        public string Description { get; set; }

        public int? Status { get; set; }

        public int? StaffId { get; set; }
    }
}
