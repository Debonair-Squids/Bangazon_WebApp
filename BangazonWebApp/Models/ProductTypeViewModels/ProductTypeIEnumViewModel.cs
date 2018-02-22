using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonWebApp.Models;
using BangazonWebApp.Data;

namespace BangazonWebApp.Models.ProductTypeViewModels
{
    public class ProductTypeIEnumViewModel
    {
        public IEnumerable<GroupedProducts> GroupedProducts { get; set; }
    }
}
