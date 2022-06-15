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
    public class DisksController : Controller
    {
        private readonly databaseconfigContext _context;

        public DisksController(databaseconfigContext context)
        {
            _context = context;
        }

        // GET: Disks
        public async Task<IActionResult> Index()
        {
            var databaseconfigContext = _context.Disks.Include(d => d.IdHddNavigation).Include(d => d.IdSsdNavigation);
            return View(await databaseconfigContext.ToListAsync());
        }

        // GET: Disks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disks
                .Include(d => d.IdHddNavigation)
                .Include(d => d.IdSsdNavigation)
                .FirstOrDefaultAsync(m => m.IdDisk == id);
            if (disk == null)
            {
                return NotFound();
            }

            return View(disk);
        }

        // GET: Disks/Create
        public IActionResult Create()
        {
            ViewData["IdHdd"] = new SelectList(_context.Hdds, "IdHdd", "Brand");
            ViewData["IdSsd"] = new SelectList(_context.Ssds, "IdSsd", "Brand");
            return View();
        }

        // POST: Disks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDisk,IdSsd,IdHdd")] Disk disk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHdd"] = new SelectList(_context.Hdds, "IdHdd", "Brand", disk.IdHdd);
            ViewData["IdSsd"] = new SelectList(_context.Ssds, "IdSsd", "Brand", disk.IdSsd);
            return View(disk);
        }

        // GET: Disks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disks.FindAsync(id);
            if (disk == null)
            {
                return NotFound();
            }
            ViewData["IdHdd"] = new SelectList(_context.Hdds, "IdHdd", "Brand", disk.IdHdd);
            ViewData["IdSsd"] = new SelectList(_context.Ssds, "IdSsd", "Brand", disk.IdSsd);
            return View(disk);
        }

        // POST: Disks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDisk,IdSsd,IdHdd")] Disk disk)
        {
            if (id != disk.IdDisk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiskExists(disk.IdDisk))
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
            ViewData["IdHdd"] = new SelectList(_context.Hdds, "IdHdd", "Brand", disk.IdHdd);
            ViewData["IdSsd"] = new SelectList(_context.Ssds, "IdSsd", "Brand", disk.IdSsd);
            return View(disk);
        }

        // GET: Disks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disks
                .Include(d => d.IdHddNavigation)
                .Include(d => d.IdSsdNavigation)
                .FirstOrDefaultAsync(m => m.IdDisk == id);
            if (disk == null)
            {
                return NotFound();
            }

            return View(disk);
        }

        // POST: Disks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disk = await _context.Disks.FindAsync(id);
            _context.Disks.Remove(disk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiskExists(int id)
        {
            return _context.Disks.Any(e => e.IdDisk == id);
        }
    }
}
