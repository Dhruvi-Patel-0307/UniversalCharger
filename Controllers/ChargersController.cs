using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversalCharger.Data;
using UniversalCharger.Models;

namespace UniversalCharger.Controllers
{
    public class ChargersController : Controller
    {
        private readonly UniversalChargerContext _context;

        public ChargersController(UniversalChargerContext context)
        {
            _context = context;
        }

        // GET: Chargers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Charger.ToListAsync());
        }

        // GET: Chargers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Charger
                .FirstOrDefaultAsync(m => m.ID == id);
            if (charger == null)
            {
                return NotFound();
            }

            return View(charger);
        }

        // GET: Chargers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chargers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Company,Colour,Price,type,voltage,Rating")] Charger charger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charger);
        }

        // GET: Chargers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Charger.FindAsync(id);
            if (charger == null)
            {
                return NotFound();
            }
            return View(charger);
        }

        // POST: Chargers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Company,Colour,Price,type,voltage,Rating")] Charger charger)
        {
            if (id != charger.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargerExists(charger.ID))
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
            return View(charger);
        }

        // GET: Chargers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Charger
                .FirstOrDefaultAsync(m => m.ID == id);
            if (charger == null)
            {
                return NotFound();
            }

            return View(charger);
        }

        // POST: Chargers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charger = await _context.Charger.FindAsync(id);
            _context.Charger.Remove(charger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChargerExists(int id)
        {
            return _context.Charger.Any(e => e.ID == id);
        }
    }
}
