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
    public class ShoppingitemsController : Controller
    {
        private readonly WebshopContext _context;

        public ShoppingitemsController(WebshopContext context)
        {
            _context = context;
        }

        // GET: Shoppingitems
        public async Task<IActionResult> Index()
        {
            var webshopContext = _context.Shoppingitems.Include(s => s.Product);
            return View(await webshopContext.ToListAsync());
        } 

        // GET: Shoppingitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingitem = await _context.Shoppingitems
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShoppingitemID == id);
            if (shoppingitem == null)
            {
                return NotFound();
            }

            return View(shoppingitem);
        }

        // GET: Shoppingitems/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name");
            ViewData["ShoppingbagID"] = new SelectList(_context.Shoppingbags, "ShoppingbagID", "ShoppingbagID");
            return View();
        }

        // POST: Shoppingitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingitemID,Quantity,ProductID,ShoppingbagID")] Shoppingitem shoppingitem)
        {
            if (ModelState.IsValid)
            {
                if (shoppingitem.Quantity==0)
                {
                    return RedirectToAction("Overzicht", "Shoppingbags", new { id = shoppingitem.ShoppingbagID });
                }
                var checkproduct = await _context.Shoppingitems.Include(i=>i.Product).Where(i => i.ProductID == shoppingitem.ProductID && i.ShoppingbagID == shoppingitem.ShoppingbagID).FirstOrDefaultAsync();
                if (checkproduct==null)
                {
                    _context.Add(shoppingitem);
                    await _context.SaveChangesAsync();
                    checkproduct = shoppingitem;
                }
                else
                {
                    checkproduct.Quantity += shoppingitem.Quantity;
                    _context.Update(checkproduct);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Overzicht", "Shoppingbags", new { id = checkproduct.ShoppingbagID});

                //else quantity aanpassen
                //redirect naar shoppingbag overzicht (new view parameters=customerid,shoppingbagid

            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", shoppingitem.ProductID);
            ViewData["ShoppingbagID"] = new SelectList(_context.Shoppingbags, "ShoppingbagID", "ShoppingbagID", shoppingitem.ShoppingbagID);
            return View(shoppingitem);
        }

        // GET: Shoppingitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingitem = await _context.Shoppingitems.FindAsync(id);
            if (shoppingitem == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", shoppingitem.ProductID);
            ViewData["ShoppingbagID"] = new SelectList(_context.Shoppingbags, "ShoppingbagID", "ShoppingbagID", shoppingitem.ShoppingbagID);
            return View(shoppingitem);
        }

        // POST: Shoppingitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingitemID,Quantity,ProductID,ShoppingbagID")] Shoppingitem shoppingitem)
        {
            if (id != shoppingitem.ShoppingitemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //kijken of qty = 0
                if (shoppingitem.Quantity==0)
                {
                    return RedirectToAction("Delete", "Shoppingitems", new { id = shoppingitem.ShoppingitemID });
                }
                try
                {
                    _context.Update(shoppingitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingitemExists(shoppingitem.ShoppingitemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Overzicht","Shoppingbags",new { id = shoppingitem.ShoppingbagID});
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", shoppingitem.ProductID);
            ViewData["ShoppingbagID"] = new SelectList(_context.Shoppingbags, "ShoppingbagID", "ShoppingbagID", shoppingitem.ShoppingbagID);
            return View(shoppingitem);
        }

        // GET: Shoppingitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingitem = await _context.Shoppingitems.FindAsync(id);
            _context.Shoppingitems.Remove(shoppingitem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Overzicht", "Shoppingbags", new { id = shoppingitem.ShoppingbagID });

        }

        // POST: Shoppingitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingitem = await _context.Shoppingitems.FindAsync(id);
            _context.Shoppingitems.Remove(shoppingitem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Overzicht", "Shoppingbags", new { id = shoppingitem.ShoppingbagID });

        }

        private bool ShoppingitemExists(int id)
        {
            return _context.Shoppingitems.Any(e => e.ShoppingitemID == id);
        }
    }
}
