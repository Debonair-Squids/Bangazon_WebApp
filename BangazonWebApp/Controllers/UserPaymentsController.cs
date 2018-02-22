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
    public class UserPaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserPaymentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: UserPayments
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var userPayment = _context.UserPayment
                .Where(pt => pt.User == user).ToList();
            //return View(await _context.UserPayment.ToListAsync());

            if (userPayment == null)
            {
                return NotFound();
            }

            return View(await _context.UserPayment.Where(pt => pt.User == user).ToListAsync());
        }

        // GET: UserPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayment
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userPayment == null)
            {
                return NotFound();
            }

            return View(userPayment);
        }

        // GET: UserPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AccountNumber")] UserPayment userPayment)
        {
            ModelState.Remove("User");
            userPayment.User = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                _context.Add(userPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPayment);
        }

        // GET: UserPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayment.SingleOrDefaultAsync(m => m.Id == id);
            if (userPayment == null)
            {
                return NotFound();
            }
            return View(userPayment);
        }

        // POST: UserPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AccountNumber")] UserPayment userPayment)
        {
            if (id != userPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaymentExists(userPayment.Id))
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
            return View(userPayment);
        }

        // GET: UserPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayment
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userPayment == null)
            {
                return NotFound();
            }

            return View(userPayment);
        }

        // POST: UserPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPayment = await _context.UserPayment.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserPayment.Remove(userPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaymentExists(int id)
        {
            return _context.UserPayment.Any(e => e.Id == id);
        }
    }
}
