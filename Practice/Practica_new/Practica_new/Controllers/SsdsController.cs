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
    public class SsdsController : Controller
    {
        private readonly databaseconfigContext _context;

        public SsdsController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Ssds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ssds.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Ssds;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameSsd.Contains(Search));
                return View(result);
            }
            return View(await _context.Ssds.ToListAsync());

        }

        // GET: Ssds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssd = await _context.Ssds
                .FirstOrDefaultAsync(m => m.IdSsd == id);
            if (ssd == null)
            {
                return NotFound();
            }

            return View(ssd);
        }

        // GET: Ssds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ssds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSsd,NameSsd,Brand,Price,SizeMemorySsd,SpeedRecord")] Ssd ssd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ssd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ssd);
        }

        // GET: Ssds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssd = await _context.Ssds.FindAsync(id);
            if (ssd == null)
            {
                return NotFound();
            }
            return View(ssd);
        }

        // POST: Ssds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSsd,NameSsd,Brand,Price,SizeMemorySsd,SpeedRecord")] Ssd ssd)
        {
            if (id != ssd.IdSsd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ssd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SsdExists(ssd.IdSsd))
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
            return View(ssd);
        }

        // GET: Ssds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ssd = await _context.Ssds
                .FirstOrDefaultAsync(m => m.IdSsd == id);
            if (ssd == null)
            {
                return NotFound();
            }

            return View(ssd);
        }

        // POST: Ssds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ssd = await _context.Ssds.FindAsync(id);
            _context.Ssds.Remove(ssd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SsdExists(int id)
        {
            return _context.Ssds.Any(e => e.IdSsd == id);
        }
    }
}
