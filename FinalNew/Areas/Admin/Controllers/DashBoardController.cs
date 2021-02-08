using FinalNew.Models.DataContext;
using FinalNew.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashBoardController : Controller
    {
        private readonly HomeSaleDbContext db;

        public DashBoardController(HomeSaleDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model =new DashBoardViewModel();

            model.ip = Request.HttpContext.Connection.RemoteIpAddress;

            model.HomeCount= db.Homes.Count();

            var thismonth = DateTime.UtcNow.AddHours(4).Month;

            model.LastMonthHomeCount = db.Homes.Where(h => h.CreatedDate.Month == thismonth).Count();

            model.AgentCount = db.Agents.Count();

            model.TodayHomeCount = db.Homes.Where(h => h.CreatedDate.Day == DateTime.UtcNow.AddHours(4).Day).Count();

            model.ClientCount = db.Users.Count() - 1 - model.AgentCount;

            model.SubscribesCount = db.Subscribes.Count();
            return View(model);
        }
        public IActionResult AccesDenied()
        {
            return View();
        }

        
    }
}
