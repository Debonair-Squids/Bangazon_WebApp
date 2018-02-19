using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BangazonWebApp.Models
{
    public class ProductRecommend
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey ("RecommenderId")]
        public virtual ApplicationUser Recommender { get; set; }

        [Required]
        [ForeignKey("RecommendeeId")]
        public virtual ApplicationUser Recommendee { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product product;

        public string Message { get; set; }
    }
}
