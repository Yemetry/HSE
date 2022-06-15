using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica_new.Models;

namespace Practica_new.Controllers
{
    public class RamsController : Controller
    {
        private readonly databaseconfigContext _context;

        public RamsController(databaseconfigContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var databaseconfigContext = _context.Rams.Include(r => r.AmountMemoryRamNavigation).Include(r => r.NumbersModulesRamNavigation).Include(r => r.TypeMemoryRamNavigation);
            return View(await databaseconfigContext.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Search)
        {
            var databaseconfigContext = _context.Rams.Include(r => r.AmountMemoryRamNavigation).Include(r => r.NumbersModulesRamNavigation).Include(r => r.TypeMemoryRamNavigation);

            if (Search!= null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.NameRam.Contains(Search));
                return View(result);
            }
            return View(await databaseconfigContext.ToListAsync());
            
        }
        [HttpPost]
        public FileResult Export()
        {
            var databaseconfigContext = _context.Rams.Include(r => r.AmountMemoryRamNavigation).Include(r => r.NumbersModulesRamNavigation).Include(r => r.TypeMemoryRamNavigation);
            databaseconfigContext entities = new databaseconfigContext();
            DataTable dt = new DataTable("RAM");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id оперативной памяти "),
                                            new DataColumn("Название оперативной памяти"),
                                            new DataColumn("Бренд"),
                                            new DataColumn("Цена"), });



            var customers = from customer in entities.Rams.Take(10)
                            select customer;

            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.IdRam, customer.NameRam, customer.Brand, customer.Price);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RAM.xlsx");
                }
            }
        }
      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .Include(r => r.AmountMemoryRamNavigation)
                .Include(r => r.NumbersModulesRamNavigation)
                .Include(r => r.TypeMemoryRamNavigation)
                .FirstOrDefaultAsync(m => m.IdRam == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

       
        public IActionResult Create()
        {
            ViewData["AmountMemoryRam"] = new SelectList(_context.SpravAmounts, "Id", "AmountMemoryRam");
            ViewData["NumbersModulesRam"] = new SelectList(_context.SpravRamModuls, "Id", "NumbersModulesRam");
            ViewData["TypeMemoryRam"] = new SelectList(_context.SpravRams, "Id", "TypeMemoryRam");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRam,NameRam,Brand,Price,AmountMemoryRam,TypeMemoryRam,NumbersModulesRam")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmountMemoryRam"] = new SelectList(_context.SpravAmounts, "Id", "AmountMemoryRam", ram.AmountMemoryRam);
            ViewData["NumbersModulesRam"] = new SelectList(_context.SpravRamModuls, "Id", "NumbersModulesRam", ram.NumbersModulesRam);
            ViewData["TypeMemoryRam"] = new SelectList(_context.SpravRams, "Id", "TypeMemoryRam", ram.TypeMemoryRam);
            return View(ram);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams.FindAsync(id);
            if (ram == null)
            {
                return NotFound();
            }
            ViewData["AmountMemoryRam"] = new SelectList(_context.SpravAmounts, "Id", "AmountMemoryRam", ram.AmountMemoryRam);
            ViewData["NumbersModulesRam"] = new SelectList(_context.SpravRamModuls, "Id", "NumbersModulesRam", ram.NumbersModulesRam);
            ViewData["TypeMemoryRam"] = new SelectList(_context.SpravRams, "Id", "TypeMemoryRam", ram.TypeMemoryRam);
            return View(ram);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRam,NameRam,Brand,Price,AmountMemoryRam,TypeMemoryRam,NumbersModulesRam")] Ram ram)
        {
            if (id != ram.IdRam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamExists(ram.IdRam))
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
            ViewData["AmountMemoryRam"] = new SelectList(_context.SpravAmounts, "Id", "AmountMemoryRam", ram.AmountMemoryRam);
            ViewData["NumbersModulesRam"] = new SelectList(_context.SpravRamModuls, "Id", "NumbersModulesRam", ram.NumbersModulesRam);
            ViewData["TypeMemoryRam"] = new SelectList(_context.SpravRams, "Id", "TypeMemoryRam", ram.TypeMemoryRam);
            return View(ram);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .Include(r => r.AmountMemoryRamNavigation)
                .Include(r => r.NumbersModulesRamNavigation)
                .Include(r => r.TypeMemoryRamNavigation)
                .FirstOrDefaultAsync(m => m.IdRam == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ram = await _context.Rams.FindAsync(id);
            _context.Rams.Remove(ram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamExists(int id)
        {
            return _context.Rams.Any(e => e.IdRam == id);
        }
    }
}
