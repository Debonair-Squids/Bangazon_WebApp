using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BangazonWebApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int Zip { get; set; }

        public virtual ICollection<Product> Product;

        public virtual ICollection<Invoice> Invoice;

        public virtual ICollection<ProductRating> ProductRating;

        public virtual ICollection<ProductLikeDislike> ProductLikeDislike;

        public virtual ICollection<ProductRecommend> ProductRecommend;


        
    }
}
