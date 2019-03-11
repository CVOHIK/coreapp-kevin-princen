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
    public class ShoppingbagsController : Controller
    {
        private readonly WebshopContext _context;

        public ShoppingbagsController(WebshopContext context)
        {
            _context = context;
        }

        // GET: Shoppingbags
        public async Task<IActionResult> Index()
        {
            var webshopContext = await _context.Shoppingbags.Include(s => s.Customer).Include(s => s.Shoppingitems).ThenInclude(item => item.Product).ToListAsync();
            foreach (var item in webshopContext)
            {           
                item.BerekenTotalPrice();
                _context.Update(item);
            }
            await _context.SaveChangesAsync();
            return View(webshopContext);
        }

        // GET: Shoppingbags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingbag = await _context.Shoppingbags
                .Include(s => s.Customer)
                .Include(s => s.Shoppingitems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(m => m.ShoppingbagID == id);
            if (shoppingbag == null)
            {
                return NotFound();
            }
            return View(shoppingbag);
        }

        //GET: Shoppingbags/Overzicht/5
        public async Task<IActionResult> Overzicht(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingbag = await _context.Shoppingbags
                .Include(s => s.Customer)
                .Include(s => s.Shoppingitems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(m => m.ShoppingbagID == id);
            if (shoppingbag == null)
            {
                return NotFound();
            }
            ViewData["Customer"] = shoppingbag.Customer;

            shoppingbag.BerekenTotalPrice();
            _context.Update(shoppingbag);
            await _context.SaveChangesAsync();

            return View(shoppingbag);
        }

        // GET: Shoppingbags/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName");
            return View();
        }

        // POST: Shoppingbags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingbagID,Date,TotalPrice,CustomerID,Closed")] Shoppingbag shoppingbag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingbag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", shoppingbag.CustomerID);
            return View(shoppingbag);
        }

        // GET: Shoppingbags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingbag = await _context.Shoppingbags.Include(s=> s.Customer).Include(s=> s.Shoppingitems).ThenInclude(i => i.Product).Where(s=>s.ShoppingbagID==id).SingleAsync();
            if (shoppingbag == null)
            {
                return NotFound();
            }
            //var shoppingitems = _context.Shoppingitems.Include(s => s.Product).Where(d => d.ShoppingbagID == shoppingbag.ShoppingbagID).ToList();
            //shoppingbag.Items = shoppingitems;
            //shoppingbag.BerekenTotalPrice();
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", shoppingbag.CustomerID);
            return View(shoppingbag);
        }

        // POST: Shoppingbags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingbagID,Date,TotalPrice,CustomerID,Closed")] Shoppingbag shoppingbag)
        {
            if (id != shoppingbag.ShoppingbagID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingbag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingbagExists(shoppingbag.ShoppingbagID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", shoppingbag.CustomerID);
            return View(shoppingbag);
        }

        // GET: Shoppingbags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingbag = await _context.Shoppingbags
                .Include(s => s.Customer)
                .Include(s=>s.Shoppingitems)
                .ThenInclude(i=>i.Product)
                .FirstOrDefaultAsync(m => m.ShoppingbagID == id);
            if (shoppingbag == null)
            {
                return NotFound();
            }
            //var shoppingitems = _context.Shoppingitems.Include(s => s.Product).Where(d => d.ShoppingbagID == shoppingbag.ShoppingbagID).ToList();
            //shoppingbag.Items = shoppingitems;
            //shoppingbag.BerekenTotalPrice();

            return View(shoppingbag);
        }

        // POST: Shoppingbags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingbag = await _context.Shoppingbags.FindAsync(id);
            _context.Shoppingbags.Remove(shoppingbag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingbagExists(int id)
        {
            return _context.Shoppingbags.Any(e => e.ShoppingbagID == id);
        }
    }
}
