using Bandas_Tarea.Data;
using Bandas_Tarea.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bandas_Tarea.Controllers
{
    public class BandasController : Controller
    {
        private readonly ApplicationDbContext db;

        public BandasController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.bandas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await db.bandas.FirstOrDefaultAsync(d => d.BandaId == id);

            if (band == null)
            {
                return NotFound();
            }

            return View(band);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bandas banda)
        {
            if (ModelState.IsValid)
            {
                db.Add(banda);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(banda);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var band = await db.bandas.FindAsync(id);

            if (band == null)
            {
                return NotFound();
            }

            return View(band);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bandas bandas)
        {
            if (id != bandas.BandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(bandas);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }

                return RedirectToAction(nameof(Index));
            }

            return View(bandas);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await db.bandas.FirstOrDefaultAsync(d => d.BandaId == id);

            if (band == null)
            {
                return NotFound();
            }

            return View(band);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var depart = await db.bandas.FindAsync(id);
            db.bandas.Remove(depart);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
