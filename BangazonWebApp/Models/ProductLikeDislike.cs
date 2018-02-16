using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class ProductLikeDislike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser User;

        [Required]
        public int ProductId { get; set; }
        public Product product;

        public string Status { get; set; }
    }
}
