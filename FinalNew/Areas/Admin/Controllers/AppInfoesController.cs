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
    public class AppInfoesController : Controller
    {
        private readonly HomeSaleDbContext _context;

        public AppInfoesController(HomeSaleDbContext context)
        {
            _context = context;
        }

        
        // GET: Admin/AppInfoes/Edit/5
        public async Task<IActionResult> Edit()
        {

            var appInfo = await _context.AppInfos.FirstOrDefaultAsync();
            if (appInfo == null)
            {
                return NotFound();
            }
            return View(appInfo);
        }

        // POST: Admin/AppInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppTitle,LogoPath,FooterLogoPath,Description,Address,Phone,Phone2,WorkOurs,Email,FacebookLink,InstagramLink,TwitterLink,HomePhoto1,HomePhoto2,HomePhoto3,AnnounceAdvantages,AgentAdvantages,CategoryPhoto1,CategoryPhoto2,CategoryPhoto3,CategoryPhoto4")] AppInfo appInfo)
        {
            if (id != appInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppInfoExists(appInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View();
            }
            return View(appInfo);
        }

        
        private bool AppInfoExists(int id)
        {
            return _context.AppInfos.Any(e => e.Id == id);
        }
    }
}
