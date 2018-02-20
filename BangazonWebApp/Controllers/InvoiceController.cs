using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BangazonWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToInvoice([Bind("Id,InvoiceDate,UserPaymentId")] int productId)
        {

            var user = _userManager.GetUserAsync(User);
            var allInvoices = _context.Invoice.ToList();
            Invoice inv = null;
            foreach (Invoice i in allInvoices)
            {
                if (i.User.Equals(user) && i.UserPayment == null)
                { 
                    inv = i;
                }
            }

            //If there is no open invoice in the DB Create a new invoice
            if (inv == null)
            {
                
                inv = new Invoice();
                inv.InvoiceDate = DateTime.Now;
                inv.UserPaymentId = null;
                if (ModelState.IsValid)
                {
                    _context.Invoice.Add(inv);
                   await _context.SaveChangesAsync();
                    
                }
            }


            //add product to invoice
            LineItem li = new LineItem();
            li.InvoiceId = inv.Id;
            li.ProductId = productId;

            _context.LineItem.Add(li);
            await _context.SaveChangesAsync();
        }
    }
}