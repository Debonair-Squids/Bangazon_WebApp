using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models.InvoiceViewModels
{
    public class InvoiceDetailsViewModel
    {
        public List<Product> OrderedProducts { get; set; }
    
        public Invoice Invoice { get; set; }

       public double InvoiceTotal { get; set; }

    public InvoiceDetailsViewModel(List<Product> orderedProducts, Invoice invoice, double invoiceTotal)
        {
            OrderedProducts = orderedProducts;
            Invoice = invoice;
            InvoiceTotal = invoiceTotal;
        }
    }

}
