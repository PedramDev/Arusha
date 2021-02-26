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
    public class OrderItemsController : Controller
    {
        private readonly ArushaContext _context;

        public OrderItemsController(ArushaContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            var arushaContext = _context.OrderItems.Include(o => o.Order).Include(o => o.Product).Include(o => o.Variant);
            return View(await arushaContext.ToListAsync());
        }

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Include(o => o.Variant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, nameof(Order.Id), nameof(Order.Id));
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName));
            ViewData["VariantId"] = new SelectList(_context.Variant, nameof(Variant.Id) , nameof(Variant.FullName));
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,VariantId,VariantName,ProductId,ProductName,CategoryName,SinglePayedPrice,SingleSellPrice,SingleBuyPrice,Quantity,Status,Id")] OrderItems orderItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, nameof(Order.Id), nameof(Order.Id), orderItems.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName), orderItems.ProductId);
            ViewData["VariantId"] = new SelectList(_context.Variant, nameof(Variant.Id), nameof(Variant.FullName), orderItems.VariantId);
            return View(orderItems);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, nameof(Order.Id), nameof(Order.Id), orderItems.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName), orderItems.ProductId);
            ViewData["VariantId"] = new SelectList(_context.Variant, nameof(Variant.Id), nameof(Variant.FullName), orderItems.VariantId);
            return View(orderItems);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,VariantId,VariantName,ProductId,ProductName,CategoryName,SinglePayedPrice,SingleSellPrice,SingleBuyPrice,Quantity,Status,Id")] OrderItems orderItems)
        {
            if (id != orderItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemsExists(orderItems.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, nameof(Order.Id), nameof(Order.Id), orderItems.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName), orderItems.ProductId);
            ViewData["VariantId"] = new SelectList(_context.Variant, nameof(Variant.Id), nameof(Variant.FullName), orderItems.VariantId);
            return View(orderItems);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Include(o => o.Variant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItems = await _context.OrderItems.FindAsync(id);
            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }
    }
}
