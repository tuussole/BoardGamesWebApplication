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
    public class TypeGamesController : Controller
    {
        private readonly DBBoardGamesContext _context;

        public TypeGamesController(DBBoardGamesContext context)
        {
            _context = context;
        }

        // GET: TypeGames
        public async Task<IActionResult> Index()
        {
            var isttp1Context = _context.TypeGames.Include(t => t.Game).Include(t => t.Type);
            return View(await isttp1Context.ToListAsync());
        }

        // GET: TypeGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeGames == null)
            {
                return NotFound();
            }

            var typeGame = await _context.TypeGames
                .Include(t => t.Game)
                .Include(t => t.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeGame == null)
            {
                return NotFound();
            }

            return View(typeGame);
        }

        // GET: TypeGames/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name");
            return View();
        }

        // POST: TypeGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,GameId")] TypeGame typeGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", typeGame.GameId);
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name", typeGame.TypeId);
            return View(typeGame);
        }

        // GET: TypeGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeGames == null)
            {
                return NotFound();
            }

            var typeGame = await _context.TypeGames.FindAsync(id);
            if (typeGame == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", typeGame.GameId);
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name", typeGame.TypeId);
            return View(typeGame);
        }

        // POST: TypeGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,GameId")] TypeGame typeGame)
        {
            if (id != typeGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeGameExists(typeGame.Id))
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
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", typeGame.GameId);
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", typeGame.TypeId);
            return View(typeGame);
        }

        // GET: TypeGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeGames == null)
            {
                return NotFound();
            }

            var typeGame = await _context.TypeGames
                .Include(t => t.Game)
                .Include(t => t.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeGame == null)
            {
                return NotFound();
            }

            return View(typeGame);
        }

        // POST: TypeGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeGames == null)
            {
                return Problem("Entity set 'DBBoardGamesContext.TypeGames'  is null.");
            }
            var typeGame = await _context.TypeGames.FindAsync(id);
            if (typeGame != null)
            {
                _context.TypeGames.Remove(typeGame);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeGameExists(int id)
        {
          return (_context.TypeGames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
