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
    public class OController : Controller
    {
        private readonly databaseconfigContext _context;

        public OController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: O
        public async Task<IActionResult> Index()
        {
            return View(await _context.Os.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Os;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameOs.Contains(Search));
                return View(result);
            }
            return View(await _context.Os.ToListAsync());

        }

        // GET: O/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var o = await _context.Os
                .FirstOrDefaultAsync(m => m.IdOs == id);
            if (o == null)
            {
                return NotFound();
            }

            return View(o);
        }

        // GET: O/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: O/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOs,NameOs,Price,Brand,Family")] O o)
        {
            if (ModelState.IsValid)
            {
                _context.Add(o);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(o);
        }

        // GET: O/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var o = await _context.Os.FindAsync(id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }

        // POST: O/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOs,NameOs,Price,Brand,Family")] O o)
        {
            if (id != o.IdOs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(o);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OExists(o.IdOs))
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
            return View(o);
        }

        // GET: O/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var o = await _context.Os
                .FirstOrDefaultAsync(m => m.IdOs == id);
            if (o == null)
            {
                return NotFound();
            }

            return View(o);
        }

        // POST: O/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var o = await _context.Os.FindAsync(id);
            _context.Os.Remove(o);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OExists(int id)
        {
            return _context.Os.Any(e => e.IdOs == id);
        }
    }
}
