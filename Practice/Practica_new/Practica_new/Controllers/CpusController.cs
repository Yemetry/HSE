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
    public class CpusController : Controller
    {
        private readonly databaseconfigContext _context;

        public CpusController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Cpus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cpus.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Cpus;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameCpu.Contains(Search));
                return View(result);
            }
            return View(await _context.Cpus.ToListAsync());

        }
        // GET: Cpus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpu = await _context.Cpus
                .FirstOrDefaultAsync(m => m.IdCpu == id);
            if (cpu == null)
            {
                return NotFound();
            }

            return View(cpu);
        }

        // GET: Cpus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cpus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCpu,NameCpu,Soket,SeriesCpu,CountCore,Brand,Price,Tdp,EnergyConsumptionCpu")] Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cpu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cpu);
        }

        // GET: Cpus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpu = await _context.Cpus.FindAsync(id);
            if (cpu == null)
            {
                return NotFound();
            }
            return View(cpu);
        }

        // POST: Cpus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCpu,NameCpu,Soket,SeriesCpu,CountCore,Brand,Price,Tdp,EnergyConsumptionCpu")] Cpu cpu)
        {
            if (id != cpu.IdCpu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cpu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CpuExists(cpu.IdCpu))
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
            return View(cpu);
        }

        // GET: Cpus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpu = await _context.Cpus
                .FirstOrDefaultAsync(m => m.IdCpu == id);
            if (cpu == null)
            {
                return NotFound();
            }

            return View(cpu);
        }

        // POST: Cpus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cpu = await _context.Cpus.FindAsync(id);
            _context.Cpus.Remove(cpu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CpuExists(int id)
        {
            return _context.Cpus.Any(e => e.IdCpu == id);
        }
    }
}
