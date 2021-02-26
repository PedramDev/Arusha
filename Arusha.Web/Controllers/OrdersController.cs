using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arusha.Domain;

namespace Arusha.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ArushaContext _context;

        public OrdersController(ArushaContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var arushaContext = _context.Order.Include(o => o.ShippingMethod).Include(o => o.User);
            return View(await arushaContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ShippingMethod)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, nameof(ShippingMethod.Id), nameof(ShippingMethod.Name));
            ViewData["UserId"] = new SelectList(_context.User, nameof(Domain.User.Id), nameof(Domain.User.FullName));
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,BillingMobile,BillingName,BillingFamily,BillingEmail,BillingGender,Description,CreatedAt,ShippingCost,ShippingMethodId,Id")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, nameof(ShippingMethod.Id), nameof(ShippingMethod.Name), order.ShippingMethodId);
            ViewData["UserId"] = new SelectList(_context.User, nameof(Domain.User.Id), nameof(Domain.User.FullName), order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, nameof(ShippingMethod.Id), nameof(ShippingMethod.Name), order.ShippingMethodId);
            ViewData["UserId"] = new SelectList(_context.User, nameof(Domain.User.Id), nameof(Domain.User.FullName), order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,BillingMobile,BillingName,BillingFamily,BillingEmail,BillingGender,Description,CreatedAt,ShippingCost,ShippingMethodId,Id")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, nameof(ShippingMethod.Id), nameof(ShippingMethod.Name), order.ShippingMethodId);
            ViewData["UserId"] = new SelectList(_context.User, nameof(Domain.User.Id), nameof(Domain.User.FullName), order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ShippingMethod)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
