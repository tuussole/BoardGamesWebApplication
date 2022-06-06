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
    public class GamesController : Controller
    {
        private readonly DBBoardGamesContext _context;

        public GamesController(DBBoardGamesContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var DBBoardGamesContext = _context.Games.Include(g => g.Age).Include(g => g.Group).Include(g => g.Nop);
            return View(await DBBoardGamesContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Age)
                .Include(g => g.Group)
                .Include(g => g.Nop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["AgeId"] = new SelectList(_context.AgeCategories, "Id", "Name");
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Nopid,Price,LeftQuantity,AgeId,GroupId")] Game game)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == game.GroupId);
            var age = await _context.AgeCategories.FirstOrDefaultAsync(g => g.Id == game.AgeId);
            var nop = await _context.NopCategories.FirstOrDefaultAsync(g => g.Id == game.Nopid);
            if (ModelState.IsValid && group != null && age != null && nop != null)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeId"] = new SelectList(_context.AgeCategories, "Id", "Id", game.AgeId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", game.GroupId);
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Id", game.Nopid);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["AgeId"] = new SelectList(_context.AgeCategories, "Id", "Name", game.AgeId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", game.GroupId);
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Name", game.Nopid);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Nopid,Price,LeftQuantity,AgeId,GroupId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            ViewData["AgeId"] = new SelectList(_context.AgeCategories, "Id", "Id", game.AgeId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", game.GroupId);
            ViewData["Nopid"] = new SelectList(_context.NopCategories, "Id", "Id", game.Nopid);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Age)
                .Include(g => g.Group)
                .Include(g => g.Nop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Games == null)
            {
                return Problem("Entity set 'DBBoardGamesContext.Games'  is null.");
            }
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
          return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
