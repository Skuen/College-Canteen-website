using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models.Users
{
    public class UsersUpdate
    {
        public int ID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? RoleId { get; set; }
    }
}
