using FinalNew.Models.DataContext;
using FinalNew.Models.Entity.Membership;
using FinalNew.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AccountController : Controller
    {

        readonly SignInManager<AppUser> signInManager;
        readonly UserManager<AppUser> userManager;

        readonly RoleManager<AppRole> roleManagar;
        readonly HomeSaleDbContext db;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManagar, HomeSaleDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.roleManagar = roleManagar;
            this.db = db;
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("login", "home", new { area = "" });
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        async public Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user;

            if (Regex.IsMatch(model.UserName, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                user = await userManager.FindByEmailAsync(model.UserName);
            }
            else
            {
                user = await userManager.FindByNameAsync(model.UserName);
            }


            if (user == null)
            {
                TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                return View(model);
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (!signInResult.Succeeded)
            {
                TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                return View(model);
            }

            string redirectLink = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(redirectLink))
            {
                return Redirect(redirectLink);
            }

            return RedirectToAction("Index", "DashBoard");
        }



        public async Task<IActionResult> Roles()
        {
            return View(await db.Roles.ToListAsync());
        }

        public IActionResult AddRole()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddRole(string name)
        {
            roleManagar.CreateAsync(new AppRole
            {
                Name = name
            }).Wait();


            return RedirectToAction(nameof(Roles));

        }


        public async Task<IActionResult> Users()
        {
           
            return View(await db.Users.ToListAsync());
        }

        public IActionResult AddUser()
        {
            
            ViewData["Roles"] = new SelectList(db.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user =await db.Users.FindAsync(id);

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "ok"
            });
        }

        [HttpPost]
        public IActionResult AddUser(string username, string email, string role, string password)
        {
            ViewData["Roles"] = new SelectList(db.Roles, "Name", "Name");

            var user = new AppUser
            {
                UserName = username,
                Email = email
            };

            if (userManager.CreateAsync(user, password).Result.Succeeded)
            {
                userManager.AddToRoleAsync(user, role).Wait();
            }

            return RedirectToAction(nameof(Users));

        }


        public async Task<IActionResult> Clients()
        {

            var clients =await userManager.GetUsersInRoleAsync("Client");

            return View(clients);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {

            var user = await db.Users.FindAsync(id);

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "ok"
            });
        }


        public async Task<IActionResult> Agents()
        {
            var agents = await userManager.GetUsersInRoleAsync("Agent");

            return View(agents);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAgent(int id)
        {

            var user = await db.Users.FindAsync(id);

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "ok"
            });
        }



    }
}
