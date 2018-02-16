using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class CustomerPayment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AccountNumber { get; set; }

    }
}
