using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Zip { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }

        public virtual ICollection<ProductRating> ProductRating { get; set; }

        public virtual ICollection<ProductLikeDislike> ProductLikeDislike { get; set; }

        [InverseProperty("Recommender")]
        public virtual ICollection<ProductRecommend> ProductRecommender { get; set; }

        [InverseProperty("Recommendee")]
        public virtual ICollection<ProductRecommend> ProductRecommendee { get; set; }



    }
}
