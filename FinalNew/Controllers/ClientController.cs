using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using FinalNew.Models.Entity.Membership;
using FinalNew.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalNew.Controllers
{

    [Authorize(Roles = "Client,SuperAdmin,Admin,Agent")]
    public class ClientController : Controller
    {
        readonly HomeSaleDbContext db;
        readonly UserManager<AppUser> userManager;


        public ClientController(HomeSaleDbContext db, UserManager<AppUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MyAnnounces()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var homes=await db.Homes
               .Where(a => a.OwnerId == int.Parse(userId))
               .Include(h => h.Category)
               .Include(h => h.Images)
               .Include(h=>h.Agent)
               .OrderBy(h=>h.CreatedDate)
               .ToListAsync();

            return View(homes);
        }

        public IActionResult AddAnnounce()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (db.Agents.Any(a => a.OwnerId == int.Parse(userId)))
            {
                ViewData["AgentTrue"] = true;
            }

            ViewData["AgentId"] = new SelectList(db.Agents, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");
            ViewData["CityId"] = new SelectList(db.Cities, "Id", "Name");
            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name");

            ViewData["BakuDistrictId"] = new SelectList(db.BakuDistricts, "Id", "Name");
            ViewData["NMRDistrictId"] = new SelectList(db.NMRDistricts, "Id", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnnounce(Home home)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                //var user=await userManager.FindByIdAsync(userId);

                //var clients= await userManager.GetUsersInRoleAsync("Client");

                //if (clients.Contains(user))
                //{
                //    if (home.SellerName==null || home.SellerName=="")
                //    {
                //        ViewBag.NullValue = "Satıcı adı qeyd olunmalıdır";
                //        return View(home);
                //    }
                //    if (home.Phone == null || home.Phone == "" )
                //    {
                //        ViewBag.NullValue = "Telefon nömrəsi qeyd olunmalıdır";
                //        return View(home);
                //    }
                //}

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
                if (home.CategoryId == 3)
                {
                    home.Area = null;
                }
                #endregion


                var intUserId = int.Parse(userId);

                home.OwnerId = intUserId;

                if (db.Agents.Any(a => a.OwnerId == intUserId))
                {
                    home.AgentId = db.Agents.FirstOrDefault(a=>a.OwnerId==intUserId).Id;
                }
                else
                {
                    home.AgentId = null;
                }


                db.Add(home);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(MyAnnounces));
            }
            ViewData["AgentId"] = new SelectList(db.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(db.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name", home.MetroId);


            ViewData["BakuDistrictId"] = new SelectList(db.BakuDistricts, "Id", "Name", home.BakuDistrictId);
            ViewData["NMRDistrictId"] = new SelectList(db.NMRDistricts, "Id", "Name", home.NMRDistrictId);


            return View(home);
        }

        public async Task<IActionResult> EditAnnounce(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await db.Homes
                .Include(h => h.Owner)
                .Include(h => h.Images).FirstOrDefaultAsync(h => h.Id == id);

            if (home == null)
            {
                return NotFound();
            }

            ViewData["AgentId"] = new SelectList(db.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(db.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name", home.MetroId);

            ViewData["BakuDistrictId"] = new SelectList(db.BakuDistricts, "Id", "Name");
            ViewData["NMRDistrictId"] = new SelectList(db.NMRDistricts, "Id", "Name");
            

            return View(home);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnnounce(int id, Home home, string[] oldFiles)
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
            if (home.CategoryId == 3)
            {
                home.Area = null;
            }
            #endregion


            if (ModelState.IsValid)
            {
                try
                {

                    if (oldFiles != null)
                    {
                        //var oldHome = db.Homes.Include(h => h.Images).FirstOrDefault(h => h.Id == id);

                        foreach (var item in db.HomeImages.Where(h => h.HomeId == home.Id))
                        {
                            if (!oldFiles.Contains(item.Path))
                            {
                                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", item.Path));
                                db.HomeImages.Remove(item);

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


                    db.Update(home);
                    await db.SaveChangesAsync();
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
                return RedirectToAction(nameof(MyAnnounces));
            }


            ViewData["AgentId"] = new SelectList(db.Agents, "Id", "Name", home.AgentId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", home.CategoryId);
            ViewData["CityId"] = new SelectList(db.Cities, "Id", "Name", home.CityId);
            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name", home.MetroId);

            ViewData["BakuDistrictId"] = new SelectList(db.BakuDistricts, "Id", "Name", home.BakuDistrictId);
            ViewData["NMRDistrictId"] = new SelectList(db.NMRDistricts, "Id", "Name", home.NMRDistrictId);
            return View(home);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAnnounce(int id)
        {
            var home = await db.Homes.FindAsync(id);

            var files = db.HomeImages.Where(h => h.HomeId == home.Id);

            db.Homes.Remove(home);

            foreach (var item in files)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", item.Path));

                db.HomeImages.Remove(item);
            }

            await db.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "ok"
            });

        }


        private bool HomeExists(int id)
        {
            return db.Homes.Any(e => e.Id == id);
        }


    }
}
