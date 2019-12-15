using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LordoftheRings.Models;

namespace LordoftheRings.Controllers
{
    public class HookupsController : Controller
    {
        private readonly CharacterCrossingContext _context;

        public HookupsController(CharacterCrossingContext context)
        {
            _context = context;
        }

        // GET: Hookups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hookups.ToListAsync());
        }

        // GET: Hookups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hookup = await _context.Hookups
                .FirstOrDefaultAsync(m => m.HookupId == id);
            if (hookup == null)
            {
                return NotFound();
            }

            return View(hookup);
        }

        // GET: Hookups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hookups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HookupId,HostId,GuestId,Location,DateTime")] Hookup hookup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hookup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hookup);
        }

        // GET: Hookups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hookup = await _context.Hookups.FindAsync(id);
            if (hookup == null)
            {
                return NotFound();
            }
            return View(hookup);
        }

        // POST: Hookups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HookupId,HostId,GuestId,Location,DateTime")] Hookup hookup)
        {
            if (id != hookup.HookupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hookup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HookupExists(hookup.HookupId))
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
            return View(hookup);
        }

        // GET: Hookups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hookup = await _context.Hookups
                .FirstOrDefaultAsync(m => m.HookupId == id);
            if (hookup == null)
            {
                return NotFound();
            }

            return View(hookup);
        }

        // POST: Hookups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hookup = await _context.Hookups.FindAsync(id);
            _context.Hookups.Remove(hookup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HookupExists(int id)
        {
            return _context.Hookups.Any(e => e.HookupId == id);
        }
    }
}
