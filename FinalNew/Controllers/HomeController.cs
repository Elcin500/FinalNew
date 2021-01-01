using FinalHomeSale.Models.DataContext;
using FinalHomeSale.Models.Entity;
using FinalHomeSale.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalHomeSale.Controllers
{
    public class HomeController : Controller
    {
        readonly HomeSaleDbContext db;

        public HomeController(HomeSaleDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.Homes = db.Homes
               .Include(h => h.Category)
               .Include(h => h.Images)
               .OrderBy(h => Guid.NewGuid())
               .Take(6)
               .ToList();

            model.Agents = db.Agents.Take(4).ToList();

            //var categories = db.Categories.OrderBy(a => Guid.NewGuid()).Take(3).ToList();
            model.Categories = db.Categories.ToList();

            model.AppInfos = db.AppInfos.FirstOrDefault();


            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");

            var cities = db.Cities.OrderBy(a=>a.Id);

            ViewData["CityId"] = new SelectList(cities, "Id", "Name",1);

            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name");

            if (Request.Cookies["card-items"]!=null)
            {
                var itemIds = Request.Cookies["card-items"].Split(",");
                if (itemIds != null && itemIds.Length > 0)
                {
                    model.Ids = itemIds.Where(i => Regex.IsMatch(i, @"\d+")).Select(i => int.Parse(i))
                        .ToArray();
                }
            }
            

            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Favorites()
        {
            if (Request.Cookies["card-items"]!=null)
            {

                var itemIds = Request.Cookies["card-items"].Split(",");

                if (itemIds != null && itemIds.Length > 0)
                {
                    int[] ids = itemIds.Where(i => Regex.IsMatch(i, @"\d+")).Select(i => int.Parse(i))
                        .ToArray();

                    var homes = db.Homes
                        .Include(h => h.Images)
                        .Include(h => h.Category)
                        .Where(h => ids.Contains(h.Id)).ToList();


                    return View(homes);
                }

            }
            

            return View();

        }
    }
}
