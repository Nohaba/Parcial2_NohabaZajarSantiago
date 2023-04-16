using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConciertoBichota.DAL;
using ConciertoBichota.DAL.Entities;

namespace ConciertoBichota.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataBaseContext _context;

        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
              return _context.Tickets != null ? 
                          View(await _context.Tickets.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Tickets'  is null.");
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var concertDB = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concertDB == null)
            {
                return NotFound();
            }

            return View(concertDB);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UseDate,IsUsed,EntranceGate")] ConcertDB concertDB)
        {
            if (ModelState.IsValid)
            {
                concertDB.Id = Guid.NewGuid();
                _context.Add(concertDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concertDB);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var concertDB = await _context.Tickets.FindAsync(id);
            if (concertDB == null)
            {
                return NotFound();
            }
            return View(concertDB);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UseDate,IsUsed,EntranceGate")] ConcertDB concertDB)
        {
            if (id != concertDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concertDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertDBExists(concertDB.Id))
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
            return View(concertDB);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var concertDB = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concertDB == null)
            {
                return NotFound();
            }

            return View(concertDB);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'DataBaseContext.Tickets'  is null.");
            }
            var concertDB = await _context.Tickets.FindAsync(id);
            if (concertDB != null)
            {
                _context.Tickets.Remove(concertDB);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertDBExists(Guid id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
