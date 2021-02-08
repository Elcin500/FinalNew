using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using FinalNew.Models.Entity.Membership;
using FinalNew.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        readonly IConfiguration conf;

        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManagar, HomeSaleDbContext db, IConfiguration conf)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.roleManagar = roleManagar;

            this.db = db;
            this.conf = conf;
        }

        public IActionResult Index(int pageIndex = 1, int pageSize = 2)
        {
            var model = new HomeViewModel();

            model.Homes = db.Homes
               .Include(h => h.Category)
               .Include(h => h.Images)
               .Take(45)
               .ToList();

            var query = model.Homes.AsQueryable()
               .OrderByDescending(a => a.CreatedDate);

            var viewModel = new PagedViewModel(query, pageIndex, pageSize);

            model.HomesPaged = viewModel;



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

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName,string password)
        {
            var tryuserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (tryuserId != null)
            {
                TempData["message"] = $"Siz artıq daxil olmusunuz";
                return RedirectToAction(nameof(Login));

            }

            if (!ModelState.IsValid)
                return View();

            AppUser user;

            if (Regex.IsMatch(userName, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                 user = await userManager.FindByEmailAsync(userName);
            }
            else
            {
                 user = await userManager.FindByNameAsync(userName);
            }

            

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
            var tryuserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (tryuserId != null)
            {
                TempData["message"] = $"Siz artıq qeydiyyatdan keçmisinin";
                return RedirectToAction(nameof(Login));
            }

            if (ModelState.IsValid)
            {

                if (db.Users.Any(a=>a.NormalizedUserName==usernameRegistr.ToUpper()))
                {
                    TempData["message"] = $"{usernameRegistr} istifadəçi adı artıq mövcuddur. Zəhmət olmasa fərqli bir ad yazın";
                    return RedirectToAction(nameof(Login));
                }
                if (db.Users.Any(a => a.NormalizedEmail == emailRegistr.ToUpper()))
                {
                    TempData["message"] = $"{emailRegistr} Bu E-mail artıq mövcuddur. Zəhmət olmasa fərqli bir email yazın";
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
                    TempData["message"] = "Xəta baş verdi";
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
                        TempData["message"] = "Xəta baş verdi";
                        return RedirectToAction(nameof(Login));
                    }
                    return RedirectToAction("AddAnnounce", "client");

                }

                return RedirectToAction(nameof(Login));

                //return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Login));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrAgent(string agentName, string agentSurname, string agentPhone, string agentPhone2, 
            string agentAdress, string facebookLink, string instagramLink, string twitterLink, string agentDescription, IFormFile image,
           string agnetUsername, string agentEmail, string agentPassword)
        {
            if (ModelState.IsValid)
            {
                var tryuserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (tryuserId!=null)
                {
                    TempData["message"] = $"Siz artıq qeydiyyatdan keçmisinin";
                }

                #region Create User
                if (db.Users.Any(a => a.NormalizedUserName == agnetUsername.ToUpper()))
                {
                    TempData["message"] = $"{agnetUsername} istifadəçi adı artıq mövcuddur. Zəhmət olmasa fərqli bir ad yazın";
                    return RedirectToAction(nameof(Login));
                }
                if (db.Users.Any(a => a.NormalizedEmail == agentEmail.ToUpper()))
                {
                    TempData["message"] = $"{agentEmail}Bu E-mail artıq mövcuddur. Zəhmət olmasa fərqli bir email yazın";
                    return RedirectToAction(nameof(Login));
                }

                var user = new AppUser
                {
                    UserName = agnetUsername,
                    Email = agentEmail
                };

                string role = "Agent";

                if (userManager.CreateAsync(user, agentPassword).Result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }

                ///////////////////////////////////////////////////////////

                #endregion

                var userNew = await userManager.FindByNameAsync(agnetUsername);

                #region Add Agent

                var agent = new Agent
                {
                    Name=agentName,
                    Surname=agentSurname,
                    Email=userNew.Email,
                    Phone=agentPhone,
                    Phone2=agentPhone2,
                    Address=agentAdress,
                    FacebookLink=facebookLink,
                    InstagramLink=instagramLink,
                    TwitterLink=twitterLink,
                    Description= agentDescription,
                    OwnerId=userNew.Id
                };

                var ext = Path.GetExtension(image.FileName);
                string purePath = $"agent-{Guid.NewGuid()}{ext}";

                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", purePath);

                using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                {
                    image.CopyTo(fs);
                }


                agent.ImagePath = purePath;


                db.Agents.Add(agent);
                await db.SaveChangesAsync();
                #endregion


                #region Sign in


                if (userNew == null)
                {
                    TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                    return RedirectToAction(nameof(Login));
                }

                //var roleNew =await db.UserRoles.FirstOrDefaultAsync(c => c.UserId == userNew.Id);

                var agents = await userManager.GetUsersInRoleAsync("Agent");


                if (agents.Contains(userNew))
                {

                    string redirectLink = Request.Query["ReturnUrl"];

                    if (!string.IsNullOrWhiteSpace(redirectLink))
                    {
                        return Redirect(redirectLink);
                    }

                    var signInResult = await signInManager.PasswordSignInAsync(userNew, agentPassword, true, true);

                    if (!signInResult.Succeeded)
                    {
                        TempData["message"] = "İstifadəçi adı və ya şifrə səhvdir";
                        return RedirectToAction(nameof(Login));
                    }

                }
                #endregion

                return RedirectToAction("AddAnnounce", "client");

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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(string name, string phone, string email, string message)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var host = conf.GetValue<string>("emailAccount:smtpServer");
                    var port = conf.GetValue<int>("emailAccount:smtpPort");
                    var userName = conf.GetValue<string>("emailAccount:userName");
                    var password = conf.GetValue<string>("emailAccount:password");
                    //var cc = conf.GetValue<string>("emailAccount:cc")
                    //    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    SmtpClient client = new SmtpClient(host, port);
                    client.Credentials = new NetworkCredential(userName, password);
                    client.EnableSsl = true;

                    var ourMail = "eracompanygroup@gmail.com";

                    MailMessage mailMessage = new MailMessage(userName, ourMail);


                    mailMessage.Subject = "Evim Saytının müştərisindən";
                    mailMessage.Body = $"Göndərənin adı : {name} <br>" +
                        $"Göndərənin e-mail adresi : {email} <br>" +
                        $"Göndərənin telefon nömrəsi : {phone} <br>" +
                        $"Göndərənin Mesajı : {message}";
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);

                    TempData["message"] = "Gönderildi";

                    return RedirectToAction(nameof(Contact));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            TempData["message"] = "Xəta baş verdi. Zəhmət olmasa daha sonra göndərin";

            return RedirectToAction(nameof(Contact));

        }


        public IActionResult AccesAccesDenied()
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            if (ModelState.IsValid)
            {
                var subscribe = new Subscribe
                {
                    Email = email
                };

                db.Add(subscribe);
                await db.SaveChangesAsync();
                return Json(new
                {
                    error = false,
                    message = "Abonə oldunuz"
                });
            }
            return Json(new
            {
                error = true,
                message = "Xəta baş verdi"
            });
        }


        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword","Home", new {email=model.Email,token=token },Request.Scheme);

                    
                    var host = conf.GetValue<string>("emailAccount:smtpServer");
                    var port = conf.GetValue<int>("emailAccount:smtpPort");
                    var userName = conf.GetValue<string>("emailAccount:userName");
                    var password = conf.GetValue<string>("emailAccount:password");

                    SmtpClient client = new SmtpClient(host, port);
                    client.Credentials = new NetworkCredential(userName, password);
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage(userName, model.Email);



                    mailMessage.Subject = "Evim Saytından";
                    mailMessage.Body = $"{passwordResetLink}";
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);


                    ViewData["Info"] = "Email adresinizə link göndərildi. Zəhmət olmasa həmin linkə daxil olun";
                    return View(model);
                }
                ViewData["Info"] = "Istifadeci tapilmadi";
                return View(model);
            }
            return View(model);
        }



        public IActionResult ResetPassword(string email,string token)
        {
            if (email==null || token==null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user!=null)
                {
                    var result =await userManager.ResetPasswordAsync(user,model.Token,model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }

                    ViewBag.Info = "Xeta bas verdi";
                    return View(model);
                }
                ViewBag.Info = "Istifadeci tapilmadi";
                return View(model);
            }

            return View(model);
        }

    }

}
