using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalHomeSale.Models.DataContext;
using FinalHomeSale.Models.Entity;
using System.IO;

namespace FinalNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomesController : Controller
    {
        private readonly HomeSaleDbContext _context;

        public HomesController(HomeSaleDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Homes
        public async Task<IActionResult> Index()
        {
            var homeSaleDbContext = _context.Homes.Include(h => h.Agent).Include(h => h.Category).Include(h => h.City).Include(h => h.Metro);
            return View(await homeSaleDbContext.ToListAsync());
        }

        // GET: Admin/Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Agent)
                .Include(h => h.Category)
                .Include(h => h.City)
                .Include(h => h.Metro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Admin/Homes/Create
        public IActionResult Create()
        {
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["MetroId"] = new SelectList(_context.Metros, "Id", "Name");
            return View();
        }

        // POST: Admin/Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Home home)
        {
            home.Images = new List<HomeImage>();

            if (home.file==null)
            {
                return View(home);
            }

            for (int i = 0; i < home.file.Length; i++)
            {
                //tttt-tttt-ttttt.js
                string ext = Path.GetExtension(home.file[i].FileName);
                string purePath = $"home-{Guid.NewGuid()}{ext}";

                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", purePath);


                using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                {
                    home.file[i].CopyTo(fs);
                }

                home.Images.Add(new HomeImage
                {
                    Path = purePath,
                    IsMain = i == home.fileSelectedIndex
                });

            }

            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(_context.Metros, "Id", "Name", home.MetroId);
            return View(home);
        }

        // GET: Admin/Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(_context.Metros, "Id", "Name", home.MetroId);
            return View(home);
        }

        // POST: Admin/Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
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
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(_context.Metros, "Id", "Name", home.MetroId);
            return View(home);
        }

        // GET: Admin/Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Agent)
                .Include(h => h.Category)
                .Include(h => h.City)
                .Include(h => h.Metro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Admin/Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.Id == id);
        }
    }
}
