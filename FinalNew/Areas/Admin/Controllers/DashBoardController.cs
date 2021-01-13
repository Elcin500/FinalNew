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
        public IActionResult Index()
        {
            //var a = Request.HttpContext.Connection.RemoteIpAddress; 

            return View();
        }
        public IActionResult AccesDenied()
        {
            return View();
        }

        
    }
}
