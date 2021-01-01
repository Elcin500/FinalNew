using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyAnnounces()
        {
            return View();
        }

        public IActionResult EditAnnounce()
        {
            return View();
        }
    }
}
