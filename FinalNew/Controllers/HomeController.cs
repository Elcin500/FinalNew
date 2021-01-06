using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using FinalNew.Models.Entity.Membership;
using FinalNew.Models.FormModel;
using FinalNew.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalNew.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        readonly SignInManager<AppUser> signInManager;
        readonly UserManager<AppUser> userManager;

        readonly RoleManager<AppRole> roleManagar;
        readonly HomeSaleDbContext db;

        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManagar, HomeSaleDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.roleManagar = roleManagar;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName,string password)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await userManager.FindByNameAsync(userName);


            if (user == null)
            {
                TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                return View();
            }

            //var role =await db.UserRoles.FirstOrDefaultAsync(c => c.UserId == user.Id);

            var clients = await userManager.GetUsersInRoleAsync("Client");

            var agents= await userManager.GetUsersInRoleAsync("Agent");

            if (clients.Contains(user) || agents.Contains(user))
            {

                string redirectLink = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(redirectLink))
                {
                    return Redirect(redirectLink);
                }

                var signInResult = await signInManager.PasswordSignInAsync(user, password, true, true);

                if (!signInResult.Succeeded)
                {
                    TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                    return View();
                }


                return RedirectToAction("MyAnnounces", "Client");
            }


            TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
            return View();


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrClient(string usernameRegistr, string emailRegistr, string passwordRegistr)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(a=>a.NormalizedUserName==usernameRegistr.ToUpper()))
                {
                    TempData["message"] = $"{usernameRegistr} istifadəçi adı artıq mövcuddur. Zəhmət olmasa fərqli bir ad yazın";
                    return RedirectToAction(nameof(Login));
                }
                if (db.Users.Any(a => a.NormalizedEmail == emailRegistr.ToUpper()))
                {
                    TempData["message"] = $"{emailRegistr}Bu E-mail artıq mövcuddur. Zəhmət olmasa fərqli bir email yazın";
                    return RedirectToAction(nameof(Login));
                }

                var user = new AppUser
                {
                    UserName = usernameRegistr,
                    Email = emailRegistr
                };

                string role = "Client";

                if (userManager.CreateAsync(user, passwordRegistr).Result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }

                ///////////////////////////////////////////////////////////
                var userNew = await userManager.FindByNameAsync(usernameRegistr);


                if (userNew == null)
                {
                    TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                    return RedirectToAction(nameof(Login));
                }

                //var roleNew =await db.UserRoles.FirstOrDefaultAsync(c => c.UserId == userNew.Id);

                var clients = await userManager.GetUsersInRoleAsync("Client");


                if (clients.Contains(userNew))
                {

                    string redirectLink = Request.Query["ReturnUrl"];

                    if (!string.IsNullOrWhiteSpace(redirectLink))
                    {
                        return Redirect(redirectLink);
                    }

                    var signInResult = await signInManager.PasswordSignInAsync(userNew, passwordRegistr, true, true);

                    if (!signInResult.Succeeded)
                    {
                        TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                        return RedirectToAction(nameof(Login));
                    }
                    return RedirectToAction("AddAnnounce", "client");

                }

                return RedirectToAction(nameof(Login));

                //return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Login));
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


        public IActionResult AccesAccesDenied()
        {
            return NotFound();
        }

    }
}
