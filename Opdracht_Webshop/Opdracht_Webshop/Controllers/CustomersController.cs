using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opdracht_Webshop.Data;
using Opdracht_Webshop.Models;

namespace Opdracht_Webshop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly WebshopContext _context;

        public CustomersController(WebshopContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            return View(await _context.Customers.ToListAsync());
        }

        //GET Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public async Task<IActionResult> Create()
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            return View();
        }

        public async Task<IActionResult> Aanmaak([Bind("CustomerID,Name,Firstname")] Customer customer)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (ModelState.IsValid)
            {
                var checklogin = await _context.Customers.Where(s => s.Firstname == customer.Firstname && s.Name == customer.Name).FirstOrDefaultAsync();
                if (checklogin == null)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    checklogin = customer;
                }
                return RedirectToAction("Verkoop", "Products", new { id = checklogin.CustomerID });

            }
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,Name,Firstname")] Customer customer)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;

            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,Name,Firstname")] Customer customer)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
