using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FinalNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
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
            var homeSaleDbContext = _context.Homes
                .Include(h => h.Agent)
                .Include(h => h.Category)
                .Include(h => h.City)
                .Include(h => h.Metro)
                .Include(h=>h.Owner);
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
                .Include(h => h.Owner)
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

            ViewData["BakuDistrictId"] = new SelectList(_context.BakuDistricts, "Id", "Name");
            ViewData["NMRDistrictId"] = new SelectList(_context.NMRDistricts, "Id", "Name");


            return View();
        }

        // POST: Admin/Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Home home)
        {
            if (ModelState.IsValid)
            {
                home.Images = new List<HomeImage>();

                if (home.file == null)
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


                #region edits
                if (home.Period == "All")
                {
                    home.Period = null;
                }
                if (home.AgentId == 0)
                {
                    home.AgentId = null;
                }
                if (home.CityId == 0)
                {
                    home.CityId = null;
                }
                if (home.MetroId == 0)
                {
                    home.MetroId = null;
                }
                if (home.AnnounceType == "Sale")
                {
                    home.Period = null;
                }
                if (home.BakuDistrictId == 0)
                {
                    home.BakuDistrictId = null;
                }
                if (home.NMRDistrictId == 0)
                {
                    home.NMRDistrictId = null;
                }

                if (home.CityId != 6 && home.CityId!=1)
                {
                    home.BakuDistrictId = null;
                    home.NMRDistrictId = null;
                }
                if (home.CityId != 1)
                {
                    home.MetroId = null;
                }
                if (home.CategoryId != 6)
                {
                    home.Floor = null;
                }
                #endregion

                var ownerId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                home.OwnerId = int.Parse(ownerId);


                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(_context.Metros, "Id", "Name", home.MetroId);



            ViewData["BakuDistrictId"] = new SelectList(_context.BakuDistricts, "Id", "Name", home.BakuDistrictId);
            ViewData["NMRDistrictId"] = new SelectList(_context.NMRDistricts, "Id", "Name", home.NMRDistrictId);


            return View(home);
        }

        // GET: Admin/Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h=>h.Owner)
                .Include(h=>h.Images).FirstOrDefaultAsync(h=>h.Id==id);

            if (home == null)
            {
                return NotFound();
            }

            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(_context.Metros, "Id", "Name", home.MetroId);

            ViewData["BakuDistrictId"] = new SelectList(_context.BakuDistricts, "Id", "Name");
            ViewData["NMRDistrictId"] = new SelectList(_context.NMRDistricts, "Id", "Name");
            //ViewBag.AnnounceTypeSelected = home.AnnounceType;


            return View(home);
        }

        // POST: Admin/Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Home home,string[] oldFiles)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            #region edits
            if (home.Period == "All")
            {
                home.Period = null;
            }
            if (home.AgentId == 0)
            {
                home.AgentId = null;
            }
            if (home.CityId == 0)
            {
                home.CityId = null;
            }
            if (home.MetroId == 0)
            {
                home.MetroId = null;
            }
            if (home.AnnounceType == "Sale")
            {
                home.Period = null;
            }
            if (home.BakuDistrictId == 0)
            {
                home.BakuDistrictId = null;
            }
            if (home.NMRDistrictId == 0)
            {
                home.NMRDistrictId = null;
            }

            if (home.CityId != 6 && home.CityId != 1)
            {
                home.BakuDistrictId = null;
                home.NMRDistrictId = null;
            }
            if (home.CityId != 1)
            {
                home.MetroId = null;
            }
            if (home.CategoryId != 6)
            {
                home.Floor = null;
            }
            #endregion


            if (ModelState.IsValid)
            {
                try
                {

                    if (oldFiles != null)
                    {
                        //var oldHome = _context.Homes.Include(h => h.Images).FirstOrDefault(h => h.Id == id);

                        foreach (var item in _context.HomeImages.Where(h => h.HomeId == home.Id))
                        {
                            if (!oldFiles.Contains(item.Path))
                            {
                                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", item.Path));
                                _context.HomeImages.Remove(item);
                                //home.Images.Remove(item);

                            }
                        }
                    }


                    if (home.file != null)
                    {
                        home.Images = new List<HomeImage>();
                        for (int i = 0; i < home.file.Length; i++)
                        {

                            string ext = Path.GetExtension(home.file[i].FileName);
                            string purePath = $"home-{Guid.NewGuid()}{ext}";

                            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", purePath);


                            using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                            {
                                home.file[i].CopyTo(fs);
                            }

                            home.Images.Add(new HomeImage
                            {
                                Path = purePath
                            });

                        }
                    }


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

            ViewData["BakuDistrictId"] = new SelectList(_context.BakuDistricts, "Id", "Name", home.BakuDistrictId);
            ViewData["NMRDistrictId"] = new SelectList(_context.NMRDistricts, "Id", "Name", home.NMRDistrictId);
            return View(home);
        }

        //// GET: Admin/Homes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var home = await _context.Homes
        //        .Include(h => h.Agent)
        //        .Include(h => h.Category)
        //        .Include(h => h.City)
        //        .Include(h => h.Metro)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (home == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(home);
        //}

        // POST: Admin/Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            var files = _context.HomeImages.Where(h=>h.HomeId==home.Id);

            _context.Homes.Remove(home);

            foreach (var item in files)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", item.Path));

                _context.HomeImages.Remove(item);
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "ok"
            });
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.Id == id);
        }
    }
}
