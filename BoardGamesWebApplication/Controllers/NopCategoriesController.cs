using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoardGamesWebApplication.Models;

namespace BoardGamesWebApplication.Controllers
{
    public class NopCategoriesController : Controller
    {
        private readonly DBBoardGamesContext _context;

        public NopCategoriesController(DBBoardGamesContext context)
        {
            _context = context;
        }

        // GET: NopCategories
        public async Task<IActionResult> Index()
        {
              return _context.NopCategories != null ? 
                          View(await _context.NopCategories.ToListAsync()) :
                          Problem("Entity set 'DBBoardGamesContext.NopCategories'  is null.");
        }

        // GET: NopCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NopCategories == null)
            {
                return NotFound();
            }

            var nopCategory = await _context.NopCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nopCategory == null)
            {
                return NotFound();
            }

            return View(nopCategory);
        }

        // GET: NopCategories/Create
        public IActionResult Create()
        {
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Name");
            return View();
        }

        // POST: NopCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To,Name")] NopCategory nopCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nopCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Name");
            return View(nopCategory);
        }

        // GET: NopCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NopCategories == null)
            {
                return NotFound();
            }

            var nopCategory = await _context.NopCategories.FindAsync(id);
            if (nopCategory == null)
            {
                return NotFound();
            }
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Name");
            return View(nopCategory);
        }

        // POST: NopCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,To")] NopCategory nopCategory)
        {
            if (id != nopCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nopCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NopCategoryExists(nopCategory.Id))
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
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Name");
            return View(nopCategory);
        }

        // GET: NopCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NopCategories == null)
            {
                return NotFound();
            }

            var nopCategory = await _context.NopCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nopCategory == null)
            {
                return NotFound();
            }

            return View(nopCategory);
        }

        // POST: NopCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NopCategories == null)
            {
                return Problem("Entity set 'DBBoardGamesContext.NopCategories'  is null.");
            }
            var nopCategory = await _context.NopCategories.FindAsync(id);
            if (nopCategory != null)
            {
                _context.NopCategories.Remove(nopCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NopCategoryExists(int id)
        {
          return (_context.NopCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
