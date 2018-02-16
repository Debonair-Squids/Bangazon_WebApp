using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonWebApp.Models
{
    public class CustomerPayment
    {
        [Key]
        public int CustomerPaymenteId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string AccountNumber { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
