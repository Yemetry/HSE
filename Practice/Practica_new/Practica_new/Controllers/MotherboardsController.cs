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
    public class MotherboardsController : Controller
    {
        private readonly databaseconfigContext _context;

        public MotherboardsController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Motherboards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motherboards.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Motherboards;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameMotherboard.Contains(Search));
                return View(result);
            }
            return View(await _context.Motherboards.ToListAsync());

        }
        // GET: Motherboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard = await _context.Motherboards
                .FirstOrDefaultAsync(m => m.IdMotherboard == id);
            if (motherboard == null)
            {
                return NotFound();
            }

            return View(motherboard);
        }

        // GET: Motherboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motherboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMotherboard,NameMotherboard,Price,Brand,SocketProcessor,NumberSlotsRam,NumberM2storageSlots,Chipset,FormFactor")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motherboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motherboard);
        }

        // GET: Motherboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard = await _context.Motherboards.FindAsync(id);
            if (motherboard == null)
            {
                return NotFound();
            }
            return View(motherboard);
        }

        // POST: Motherboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMotherboard,NameMotherboard,Price,Brand,SocketProcessor,NumberSlotsRam,NumberM2storageSlots,Chipset,FormFactor")] Motherboard motherboard)
        {
            if (id != motherboard.IdMotherboard)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motherboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotherboardExists(motherboard.IdMotherboard))
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
            return View(motherboard);
        }

        // GET: Motherboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard = await _context.Motherboards
                .FirstOrDefaultAsync(m => m.IdMotherboard == id);
            if (motherboard == null)
            {
                return NotFound();
            }

            return View(motherboard);
        }

        // POST: Motherboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motherboard = await _context.Motherboards.FindAsync(id);
            _context.Motherboards.Remove(motherboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotherboardExists(int id)
        {
            return _context.Motherboards.Any(e => e.IdMotherboard == id);
        }
    }
}
