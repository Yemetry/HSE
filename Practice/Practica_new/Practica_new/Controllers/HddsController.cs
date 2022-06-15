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
    public class HddsController : Controller
    {
        private readonly databaseconfigContext _context;

        public HddsController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Hdds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hdds.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Hdds;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameHdd.Contains(Search));
                return View(result);
            }
            return View(await _context.Hdds.ToListAsync());

        }
        // GET: Hdds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hdd = await _context.Hdds
                .FirstOrDefaultAsync(m => m.IdHdd == id);
            if (hdd == null)
            {
                return NotFound();
            }

            return View(hdd);
        }

        // GET: Hdds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hdds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHdd,NameHdd,Brand,Price,SpeedDisk,SizeMemoryHdd")] Hdd hdd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hdd);
        }

        // GET: Hdds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hdd = await _context.Hdds.FindAsync(id);
            if (hdd == null)
            {
                return NotFound();
            }
            return View(hdd);
        }

        // POST: Hdds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHdd,NameHdd,Brand,Price,SpeedDisk,SizeMemoryHdd")] Hdd hdd)
        {
            if (id != hdd.IdHdd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hdd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HddExists(hdd.IdHdd))
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
            return View(hdd);
        }

        // GET: Hdds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hdd = await _context.Hdds
                .FirstOrDefaultAsync(m => m.IdHdd == id);
            if (hdd == null)
            {
                return NotFound();
            }

            return View(hdd);
        }

        // POST: Hdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hdd = await _context.Hdds.FindAsync(id);
            _context.Hdds.Remove(hdd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HddExists(int id)
        {
            return _context.Hdds.Any(e => e.IdHdd == id);
        }
    }
}
