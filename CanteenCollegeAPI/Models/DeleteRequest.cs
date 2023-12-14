using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models
{
    public class DeleteRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
