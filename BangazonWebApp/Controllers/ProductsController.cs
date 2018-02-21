using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BangazonWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.ProductType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create([Bind("Name,Price,Description,Quantity,QuantitySold,DateAdded,LocalDelivery,ImgUrl,ProductTypeId")] Product product)
=======
        public async Task<IActionResult> Create([Bind("Id, Name,Price,Description,Quantity,QuantitySold,DateAdded,LocalDelivery,ImgUrl,ProductTypeId")] Product product)
>>>>>>> d34220672bef85e56697176d2e3df1fa1288fd46
        {
            var currentUser = _userManager.GetUserAsync(HttpContext.User);
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                product.User = await currentUser;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 
<<<<<<< HEAD
=======

>>>>>>> d34220672bef85e56697176d2e3df1fa1288fd46
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Quantity,QuantitySold,DateAdded,LocalDelivery,ImgUrl,ProductTypeId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        //POST: AddProductToInvoice
        //Method to add a product to an open invoice.
        //Author: Tyler Bowman
        //Required Parameters: int product Id

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToInvoice([Bind("Id,InvoiceDate,UserPaymentId")] int productId)
        {

            var user = _userManager.GetUserAsync(HttpContext.User);
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
                ModelState.Remove("User");
                if (ModelState.IsValid)
                {
                    inv.User = await user;
                    _context.Invoice.Add(inv);
                    await _context.SaveChangesAsync();
             
                }
            }


            //add product to invoice
            LineItem li = new LineItem();
            li.InvoiceId = inv.Id;
            li.ProductId = productId;

            if (ModelState.IsValid)
            {
                _context.LineItem.Add(li);
                await _context.SaveChangesAsync();
            }
                return View();
        }


        //DELETE 
        //Method to delete a product from an open invoice.
        //Author: Tyler Bowman
        //Required Parameters: int product Id
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductFromInvoice(int productId)
        {
            var user = _userManager.GetUserAsync(HttpContext.User);
            var allInvoices = _context.Invoice.ToList();
            Invoice activeInvoice = null;

            foreach(Invoice i in allInvoices)
            {
                if (i.User.Equals(user) && i.UserPaymentId == null)
                {
                    activeInvoice = i;
                }  
            }

            var LineItemToDelete = _context.LineItem.Where(li => li.InvoiceId == activeInvoice.Id && li.ProductId == productId).Single();

            if (ModelState.IsValid)
            {
                _context.LineItem.Remove(LineItemToDelete);
                await _context.SaveChangesAsync();
            }
                return View();


        }
    }
}
