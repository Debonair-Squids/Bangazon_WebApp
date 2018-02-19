using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BangazonWebApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; } 

        [Required]
        public int Quantity { get; set; }

        public int QuantitySold { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required]
        public bool LocalDelivery { get; set; } = false;

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public virtual ICollection<LineItem> LineItem { get; set; }
    }
}
