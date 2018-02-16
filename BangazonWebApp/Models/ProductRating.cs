using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class ProductRating
    {
        [Required]
        int Id { get; set; }

        [Required]
        int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        
        public int Rating { get; set; }

    }
}
