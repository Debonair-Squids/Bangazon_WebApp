using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BangazonWebApp.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InvoiceDate { get; set; }

        
        public int? UserPaymentId { get; set; }
        
        public UserPayment UserPayment { get; set; }
      
        [Required]
        public ApplicationUser User { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }

    }
}
