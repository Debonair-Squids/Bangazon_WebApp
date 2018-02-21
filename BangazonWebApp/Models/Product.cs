using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace BangazonWebApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(50)]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Description is Required")]
        [StringLength(255)]
        public string Description { get; set; } 

        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }

        public int? QuantitySold { get; set; } = 0;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required]
        public bool LocalDelivery { get; set; } = false;
       
        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public virtual ICollection<LineItem> LineItem { get; set; }
    }
}
