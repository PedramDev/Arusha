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
    public class VariantsController : Controller
    {
        private readonly ArushaContext _context;

        public VariantsController(ArushaContext context)
        {
            _context = context;
        }

        // GET: Variants
        public async Task<IActionResult> Index()
        {
            var arushaContext = _context.Variant.Include(v => v.Color).Include(v => v.Product);
            return View(await arushaContext.ToListAsync());
        }

        // GET: Variants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variant = await _context.Variant
                .Include(v => v.Color)
                .Include(v => v.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variant == null)
            {
                return NotFound();
            }

            return View(variant);
        }

        // GET: Variants/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, nameof(Color.Id), nameof(Color.FullName));
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName));
            return View();
        }

        // POST: Variants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreatedAt,Name,Stock,Code,ProductId,ColorId,Id")] Variant variant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, nameof(Color.Id), nameof(Color.FullName), variant.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName), variant.ProductId);
            return View(variant);
        }

        // GET: Variants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variant = await _context.Variant.FindAsync(id);
            if (variant == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Color, nameof(Color.Id), nameof(Color.FullName), variant.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.FullName), variant.ProductId);
            return View(variant);
        }

        // POST: Variants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreatedAt,Name,Stock,Code,ProductId,ColorId,Id")] Variant variant)
        {
            if (id != variant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariantExists(variant.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Color, nameof(Color.Id), nameof(Color.FullName), variant.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Product, nameof(Product.Id) , nameof(Product.FullName), variant.ProductId);
            return View(variant);
        }

        // GET: Variants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variant = await _context.Variant
                .Include(v => v.Color)
                .Include(v => v.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variant == null)
            {
                return NotFound();
            }

            return View(variant);
        }

        // POST: Variants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variant = await _context.Variant.FindAsync(id);
            _context.Variant.Remove(variant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariantExists(int id)
        {
            return _context.Variant.Any(e => e.Id == id);
        }
    }
}
