using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerCRUDopr.Models;

namespace CustomerCRUDopr.Controllers
{
    public class Customer1Controller : Controller
    {
        private readonly CustomerCrudContext _context;

        public Customer1Controller(CustomerCrudContext context)
        {
            _context = context;
        }

        // GET: Customer1
        public async Task<IActionResult> Index()
        {
              return _context.Customer1s != null ? 
                          View(await _context.Customer1s.ToListAsync()) :
                          Problem("Entity set 'CustomerCrudContext.Customer1s'  is null.");
        }

        // GET: Customer1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer1s == null)
            {
                return NotFound();
            }

            var customer1 = await _context.Customer1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer1 == null)
            {
                return NotFound();
            }

            return View(customer1);
        }

        // GET: Customer1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Email")] Customer1 customer1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer1);
        }

        // GET: Customer1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer1s == null)
            {
                return NotFound();
            }

            var customer1 = await _context.Customer1s.FindAsync(id);
            if (customer1 == null)
            {
                return NotFound();
            }
            return View(customer1);
        }

        // POST: Customer1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Email")] Customer1 customer1)
        {
            if (id != customer1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer1Exists(customer1.Id))
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
            return View(customer1);
        }

        // GET: Customer1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer1s == null)
            {
                return NotFound();
            }

            var customer1 = await _context.Customer1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer1 == null)
            {
                return NotFound();
            }

            return View(customer1);
        }

        // POST: Customer1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer1s == null)
            {
                return Problem("Entity set 'CustomerCrudContext.Customer1s'  is null.");
            }
            var customer1 = await _context.Customer1s.FindAsync(id);
            if (customer1 != null)
            {
                _context.Customer1s.Remove(customer1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customer1Exists(int id)
        {
          return (_context.Customer1s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
