using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BangazonWebApp.Models.InvoiceViewModels;

namespace BangazonWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public InvoiceController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {

            var currentUser = _userManager.GetUserAsync(HttpContext.User);
            Invoice currentInvoice = _context.Invoice.Where(i => i.User.Equals(currentUser) && i.UserPaymentId == null).SingleOrDefault();
            List<Product> orderedProducts = new List<Product>();
            double invoiceTotal = 0;

            if (currentInvoice != null)
            {
                List<LineItem> invoiceLineItems = _context.LineItem.Where(li => li.InvoiceId == currentInvoice.Id).ToList();

                foreach (LineItem li in invoiceLineItems)
                {
                    Product product = _context.Product.Where(p => p.Id == li.ProductId).Single();
                    invoiceTotal += product.Price;
                    orderedProducts.Add(product);
                }
            }

            InvoiceDetailsViewModel details = new InvoiceDetailsViewModel(orderedProducts, currentInvoice, invoiceTotal);

            return View(details);
            
            
        }

        public async Task<IActionResult> CompleteInvoice(int InvoiceId, int userPaymentId)
        {
            Invoice openInvoice = _context.Invoice.Where(i => i.Id == InvoiceId).Single();

            if(openInvoice != null)
            {
                openInvoice.UserPaymentId = userPaymentId;
                ModelState.Remove("User");
                if(ModelState.IsValid)
                {
                    openInvoice.User = await _userManager.GetUserAsync(HttpContext.User);
                    _context.Invoice.Update(openInvoice);
                    await _context.SaveChangesAsync();
                }

                
            }
                return View();
        }

        public async Task<IActionResult> CancelInvoice(int InvoiceId)
        {
            Invoice inv = _context.Invoice.Where(i => i.Id == InvoiceId).Single();

            if(inv != null)
            {
                _context.Invoice.Remove(inv);
                await _context.SaveChangesAsync();
            }
            return View();
        }
        
    }
}