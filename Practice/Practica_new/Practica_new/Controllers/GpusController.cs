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
    public class GpusController : Controller
    {
        private readonly databaseconfigContext _context;

        public GpusController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Gpus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gpus.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Gpus;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameGpu.Contains(Search));
                return View(result);
            }
            return View(await _context.Gpus.ToListAsync());

        }
        // GET: Gpus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpus
                .FirstOrDefaultAsync(m => m.IdGpu == id);
            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // GET: Gpus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gpus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGpu,NameGpu,Price,Brand,GraphicsProc,AmountMemory,TypeMemory,EnergyConsumptionGpu")] Gpu gpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gpu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gpu);
        }

        // GET: Gpus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpus.FindAsync(id);
            if (gpu == null)
            {
                return NotFound();
            }
            return View(gpu);
        }

        // POST: Gpus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGpu,NameGpu,Price,Brand,GraphicsProc,AmountMemory,TypeMemory,EnergyConsumptionGpu")] Gpu gpu)
        {
            if (id != gpu.IdGpu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gpu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GpuExists(gpu.IdGpu))
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
            return View(gpu);
        }

        // GET: Gpus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpus
                .FirstOrDefaultAsync(m => m.IdGpu == id);
            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // POST: Gpus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gpu = await _context.Gpus.FindAsync(id);
            _context.Gpus.Remove(gpu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GpuExists(int id)
        {
            return _context.Gpus.Any(e => e.IdGpu == id);
        }
    }
}
