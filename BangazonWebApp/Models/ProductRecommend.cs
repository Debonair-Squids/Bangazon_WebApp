﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class ProductRecommend
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser Recommender;

        [Required]
        public ApplicationUser Recommendee;

        [Required]
        public int ProductId { get; set; }
        public Product product;

        public string Message { get; set; }
    }
}
