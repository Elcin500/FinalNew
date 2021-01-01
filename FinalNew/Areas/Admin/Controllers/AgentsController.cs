using FinalHomeSale.Models.DataContext;
using FinalHomeSale.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgentsController : Controller
    {
        private readonly HomeSaleDbContext _context;

        public AgentsController(HomeSaleDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Agents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agents.ToListAsync());
        }

        // GET: Admin/Agents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Admin/Agents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,Phone2,Email,Address,Agency,Description,FacebookLink,InstagramLink,TwitterLink,ImagePath,CreatedDate")] Agent agent, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var ext = Path.GetExtension(image.FileName);
                string purePath = $"agent-{Guid.NewGuid()}{ext}";

                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", purePath);

                using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                {
                    image.CopyTo(fs);
                }


                agent.ImagePath = purePath;


                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Admin/Agents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Admin/Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Phone,Phone2,Email,Address,Agency,Description,FacebookLink,InstagramLink,TwitterLink,ImagePath,CreatedDate")] Agent agent, IFormFile image)
        {
            if (id != agent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string path = _context.Agents.AsNoTracking().FirstOrDefault(p => p.Id == id)?.ImagePath;
                    if (image != null)
                    {

                        var ext = Path.GetExtension(image.FileName);
                        string purePath = $"agent-{Guid.NewGuid()}{ext}";

                        string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", purePath);

                        using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                        {
                            image.CopyTo(fs);
                        }

                        agent.ImagePath = purePath;
                    }
                    else if (agent.ImagePathTemp != null)
                    {
                        agent.ImagePath = agent.ImagePathTemp;
                    }



                    _context.Update(agent);
                    await _context.SaveChangesAsync();


                    if (!string.IsNullOrWhiteSpace(path) && string.IsNullOrWhiteSpace(agent.ImagePathTemp))
                    {
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", path));
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.Id))
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
            return View(agent);
        }

        // GET: Admin/Agents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Admin/Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agent = await _context.Agents.FindAsync(id);

            string file = agent.ImagePath;

            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();

            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file));


            return Json(new
            {
                error = false,
                message = "ok"
            });
        }

        private bool AgentExists(int id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
