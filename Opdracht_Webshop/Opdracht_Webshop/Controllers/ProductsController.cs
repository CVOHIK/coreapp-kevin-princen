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
    public class ProductsController : Controller
    {
        private readonly WebshopContext _context;

        public ProductsController(WebshopContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {

            var loginuser = await _context.Customers.FindAsync(1);
           ViewData["Customer"] = loginuser;
            return View(await _context.Products.ToListAsync());
        }

        //GET: Products/Verkoop
        public async Task<IActionResult> Verkoop(int? id)
        {
            if (id != null)
            {
                var customer = await _context.Customers.Include(c=>c.Bags).Where(c=>c.CustomerID==id).FirstOrDefaultAsync();
                Shoppingbag bag;
                if (customer.Bags.Count==0)
                {
                    bag = new Shoppingbag() { Date = DateTime.Now, Customer = customer, CustomerID = customer.CustomerID };
                    _context.Add(bag);
                    await _context.SaveChangesAsync();
                    //customer.Bags.Add(bag);
                }
                else
                {
                    bag = customer.Bags.FirstOrDefault(b => b.Closed == false);
                }
                ViewData["Customer"] = customer;
                ViewData["Shoppingbag"] = bag;
            }
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Info/5
        public async Task<IActionResult> Info(int? id, int? customerid)
        {
            var loginuser = await _context.Customers.FindAsync(customerid);
            ViewData["Customer"] = loginuser;

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Price")] Product product)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Price")] Product product)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id != product.ProductID)
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
                    if (!ProductExists(product.ProductID))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
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
            var loginuser = await _context.Customers.FindAsync(1);
            ViewData["Customer"] = loginuser;
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
