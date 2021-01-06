using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using Microsoft.AspNetCore.Authorization;

namespace FinalNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class MetroesController : Controller
    {
        private readonly HomeSaleDbContext _context;

        public MetroesController(HomeSaleDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Metroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Metros.ToListAsync());
        }

        // GET: Admin/Metroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metro = await _context.Metros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metro == null)
            {
                return NotFound();
            }

            return View(metro);
        }

        // GET: Admin/Metroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Metroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Metro metro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metro);
        }

        // GET: Admin/Metroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metro = await _context.Metros.FindAsync(id);
            if (metro == null)
            {
                return NotFound();
            }
            return View(metro);
        }

        // POST: Admin/Metroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Metro metro)
        {
            if (id != metro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetroExists(metro.Id))
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
            return View(metro);
        }

        // POST: Admin/Metroes/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metro = await _context.Metros.FindAsync(id);
            _context.Metros.Remove(metro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetroExists(int id)
        {
            return _context.Metros.Any(e => e.Id == id);
        }
    }
}
