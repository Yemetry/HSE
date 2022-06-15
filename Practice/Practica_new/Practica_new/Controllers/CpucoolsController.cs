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
    public class CpucoolsController : Controller
    {
        private readonly databaseconfigContext _context;

        public CpucoolsController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Cpucools
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cpucools.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Cpucools;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameCpucool.Contains(Search));
                return View(result);
            }
            return View(await _context.Cpucools.ToListAsync());

        }

        // GET: Cpucools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpucool = await _context.Cpucools
                .FirstOrDefaultAsync(m => m.IdCpucool == id);
            if (cpucool == null)
            {
                return NotFound();
            }

            return View(cpucool);
        }

        // GET: Cpucools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cpucools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCpucool,NameCpucool,Price,Brand,CompatibleSockets,Tdp")] Cpucool cpucool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cpucool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cpucool);
        }

        // GET: Cpucools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpucool = await _context.Cpucools.FindAsync(id);
            if (cpucool == null)
            {
                return NotFound();
            }
            return View(cpucool);
        }

        // POST: Cpucools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCpucool,NameCpucool,Price,Brand,CompatibleSockets,Tdp")] Cpucool cpucool)
        {
            if (id != cpucool.IdCpucool)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cpucool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CpucoolExists(cpucool.IdCpucool))
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
            return View(cpucool);
        }

        // GET: Cpucools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpucool = await _context.Cpucools
                .FirstOrDefaultAsync(m => m.IdCpucool == id);
            if (cpucool == null)
            {
                return NotFound();
            }

            return View(cpucool);
        }

        // POST: Cpucools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cpucool = await _context.Cpucools.FindAsync(id);
            _context.Cpucools.Remove(cpucool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CpucoolExists(int id)
        {
            return _context.Cpucools.Any(e => e.IdCpucool == id);
        }
    }
}
