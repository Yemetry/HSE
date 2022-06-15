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
    public class CarcassesController : Controller
    {
        private readonly databaseconfigContext _context;

        public CarcassesController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Carcasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carcasses.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Carcasses;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameCarcass.Contains(Search));
                return View(result);
            }
            return View(await _context.Carcasses.ToListAsync());

        }

        // GET: Carcasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carcass = await _context.Carcasses
                .FirstOrDefaultAsync(m => m.IdCarcass == id);
            if (carcass == null)
            {
                return NotFound();
            }

            return View(carcass);
        }

        // GET: Carcasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carcasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarcass,NameCarcass,Brand,Price,MotherboardFormFactor,NumberUsbOutputs,NumberAudioOutputs")] Carcass carcass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carcass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carcass);
        }

        // GET: Carcasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carcass = await _context.Carcasses.FindAsync(id);
            if (carcass == null)
            {
                return NotFound();
            }
            return View(carcass);
        }

        // POST: Carcasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarcass,NameCarcass,Brand,Price,MotherboardFormFactor,NumberUsbOutputs,NumberAudioOutputs")] Carcass carcass)
        {
            if (id != carcass.IdCarcass)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carcass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarcassExists(carcass.IdCarcass))
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
            return View(carcass);
        }

        // GET: Carcasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carcass = await _context.Carcasses
                .FirstOrDefaultAsync(m => m.IdCarcass == id);
            if (carcass == null)
            {
                return NotFound();
            }

            return View(carcass);
        }

        // POST: Carcasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carcass = await _context.Carcasses.FindAsync(id);
            _context.Carcasses.Remove(carcass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarcassExists(int id)
        {
            return _context.Carcasses.Any(e => e.IdCarcass == id);
        }
    }
}
