using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonWebApp.Data;
using BangazonWebApp.Models.ProductTypeViewModels;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BangazonWebApp.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductTypeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ProductTypeIEnumViewModel();

            // Build list of Product instances for display in view
            // LINQ is awesome
            model.GroupedProducts = await (
                from t in _context.ProductType
                join p in _context.Product
                on t.Id equals p.ProductTypeId
                group new { t, p } by new { t.Id, t.Name } into grouped
                select new GroupedProducts
                {
                    TypeId = grouped.Key.Id,
                    TypeName = grouped.Key.Name,
                    ProductCount = grouped.Select(x => x.p.Id).Count(),
                    Products = grouped.Select(x => x.p).Take(3)
                }).ToListAsync();

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
















    // GET: Products/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var product = await _context.Product
    //        .Include(p => p.ProductType)
    //        .SingleOrDefaultAsync(m => m.Id == id);
    //    if (product == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(product);
    //}
//}
    }


