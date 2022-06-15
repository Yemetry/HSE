using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica_new.Models;

namespace Practica_new.Controllers
{
    public class PsusController : Controller
    {
        private readonly databaseconfigContext _context;

        public PsusController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Psus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Psus.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Psus;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NamePsu.Contains(Search));
                return View(result);
            }
            return View(await _context.Psus.ToListAsync());

        }

        // GET: Psus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psu = await _context.Psus
                .FirstOrDefaultAsync(m => m.IdPsu == id);
            if (psu == null)
            {
                return NotFound();
            }

            return View(psu);
        }

        // GET: Psus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Psus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPsu,NamePsu,Price,Brand,AmountPower,Certificate")] Psu psu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(psu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(psu);
        }

        // GET: Psus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psu = await _context.Psus.FindAsync(id);
            if (psu == null)
            {
                return NotFound();
            }
            return View(psu);
        }

        // POST: Psus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPsu,NamePsu,Price,Brand,AmountPower,Certificate")] Psu psu)
        {
            if (id != psu.IdPsu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(psu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PsuExists(psu.IdPsu))
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
            return View(psu);
        }

        // GET: Psus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psu = await _context.Psus
                .FirstOrDefaultAsync(m => m.IdPsu == id);
            if (psu == null)
            {
                return NotFound();
            }

            return View(psu);
        }

        // POST: Psus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var psu = await _context.Psus.FindAsync(id);
            _context.Psus.Remove(psu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PsuExists(int id)
        {
            return _context.Psus.Any(e => e.IdPsu == id);
        }
    }
}
