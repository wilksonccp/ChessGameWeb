using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChessGame.Data;
using ChessGame.Models;

namespace ChessGame.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ChessDbContext _context;

        public MatchesController(ChessDbContext context)
        {
            _context = context;
        }

        // GET: ChessMatches
        public async Task<IActionResult> Index()
        {
            var chessDbContext = _context.ChessMatches.Include(c => c.BlackPlayer).Include(c => c.WhitePlayer);
            return View(await chessDbContext.ToListAsync());
        }

        // GET: ChessMatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chessMatch = await _context.ChessMatches
                .Include(c => c.BlackPlayer)
                .Include(c => c.WhitePlayer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chessMatch == null)
            {
                return NotFound();
            }

            return View(chessMatch);
        }

        // GET: ChessMatches/Create
        public IActionResult Create()
        {
            ViewData["BlackPlayerId"] = new SelectList(_context.Players, "Id", "Name");
            ViewData["WhitePlayerId"] = new SelectList(_context.Players, "Id", "Name");
            return View();
        }

        // POST: ChessMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameMode,WhitePlayerId,BlackPlayerId,IsActive,IsCheckmate,IsDraw,Turn,StartTime,EndTime")] ChessMatch chessMatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chessMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlackPlayerId"] = new SelectList(_context.Players, "Id", "Name", chessMatch.BlackPlayerId);
            ViewData["WhitePlayerId"] = new SelectList(_context.Players, "Id", "Name", chessMatch.WhitePlayerId);
            return View(chessMatch);
        }

        // GET: ChessMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chessMatch = await _context.ChessMatches.FindAsync(id);
            if (chessMatch == null)
            {
                return NotFound();
            }
            ViewData["BlackPlayerId"] = new SelectList(_context.Players, "Id", "Name", chessMatch.BlackPlayerId);
            ViewData["WhitePlayerId"] = new SelectList(_context.Players, "Id", "Name", chessMatch.WhitePlayerId);
            return View(chessMatch);
        }

        // POST: ChessMatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameMode,WhitePlayerId,BlackPlayerId,IsActive,IsCheckmate,IsDraw,Turn,StartTime,EndTime")] ChessMatch chessMatch)
        {
            if (id != chessMatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chessMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChessMatchExists(chessMatch.Id))
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
            ViewData["BlackPlayerId"] = new SelectList(_context.Players, "Id", "Name", chessMatch.BlackPlayerId);
            ViewData["WhitePlayerId"] = new SelectList(_context.Players, "Id", "Name", chessMatch.WhitePlayerId);
            return View(chessMatch);
        }

        // GET: ChessMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chessMatch = await _context.ChessMatches
                .Include(c => c.BlackPlayer)
                .Include(c => c.WhitePlayer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chessMatch == null)
            {
                return NotFound();
            }

            return View(chessMatch);
        }

        // POST: ChessMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chessMatch = await _context.ChessMatches.FindAsync(id);
            if (chessMatch != null)
            {
                _context.ChessMatches.Remove(chessMatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChessMatchExists(int id)
        {
            return _context.ChessMatches.Any(e => e.Id == id);
        }
    }
}
