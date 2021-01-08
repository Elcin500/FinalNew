using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using FinalNew.Models.Entity.Membership;
using FinalNew.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalNew.Controllers
{
    [AllowAnonymous]
    public class AnnouncesController : Controller
    {
        readonly HomeSaleDbContext db;
        readonly IConfiguration conf;
        readonly UserManager<AppUser> userManager;


        public AnnouncesController(HomeSaleDbContext db, IConfiguration conf, UserManager<AppUser> userManager)
        {
            this.db = db;
            this.conf = conf;
            this.userManager = userManager;
        }

      

        public IActionResult Index(string announceType, int categoryId, int cityId, int metroId,
            int minPrice, int maxPrice, int minArea, int maxArea, int minRoom, int minBath)
        {
            
            if (string.IsNullOrWhiteSpace(announceType))
            {
                announceType = "Sale";
            }

            var model = new HomeViewModel();

            model.Homes = db.Homes
            .Include(h => h.Category)
            .Include(h => h.Metro)
            .Include(h => h.City)
            .Include(h => h.Images)
            .Where(h => h.AnnounceType == announceType)
            .ToList();

            #region search

            if (categoryId != 0)
            {
                model.Homes = model.Homes.Where(h => h.CategoryId == categoryId).ToList();
            }
            if (metroId != 0)
            {
                model.Homes = model.Homes.Where(h => h.MetroId == metroId).ToList();
            }
            if (cityId != 0)
            {
                model.Homes = model.Homes.Where(h => h.CityId == cityId).ToList();
            }
            if (cityId != 0)
            {
                model.Homes = model.Homes.Where(h => h.CityId == cityId).ToList();
            }

            if (minPrice != 0)
            {
                model.Homes = model.Homes.Where(h => h.Price >= minPrice).ToList();
            }
            if (maxPrice != 0)
            {
                model.Homes = model.Homes.Where(h => h.Price <= maxPrice).ToList();
            }

            if (minRoom != 0)
            {
                model.Homes = model.Homes.Where(h => h.RoomCount >= minRoom).ToList();
            }
            if (minBath != 0)
            {
                model.Homes = model.Homes.Where(h => h.BathCount >= minBath).ToList();
            }
            #endregion

            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name",categoryId);

            var cities = db.Cities.OrderBy(a => a.Id);

            ViewData["CityId"] = new SelectList(cities, "Id", "Name", cityId);

            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name",metroId);

            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name", metroId);


            #region Selected items

            if (announceType == null || announceType == "")
            {
                ViewBag.AnnounceTypeSelected = "Sale";
            }
            else
            {
                ViewBag.AnnounceTypeSelected = announceType;
            }


            if (minPrice==0)
            {
                ViewBag.MinPriceSelected = "";
            }
            else
            {
                ViewBag.MinPriceSelected = minPrice;
            }

            if (maxPrice == 0)
            {
                ViewBag.MaxPriceSelected = "";
            }
            else
            {
                ViewBag.MaxPriceSelected = maxPrice;
            }

            if (minArea == 0)
            {
                ViewBag.MinAreaSelected = "";
            }
            else
            {
                ViewBag.MinAreaSelected = minArea;
            }

            if (maxArea == 0)
            {
                ViewBag.MaxAreaSelected = "";
            }
            else
            {
                ViewBag.MaxAreaSelected = maxArea;
            }

            if (minRoom == 0)
            {
                ViewBag.MinRoomSelected = @"<option hidden value='0'>All</option>";
            }
            else if (minRoom == 5)
            {
                ViewBag.MinRoomSelected = @"<option hidden value='5'>5 və daha çox</option>";
            }
            else
            {
                ViewBag.MinRoomSelected = @$"<option hidden>{minRoom}</option>";
            }

            if (minBath == 0)
            {
                ViewBag.MinBathSelected = @"<option hidden value='0'>All</option>";
            }
            else if (minBath == 4)
            {
                ViewBag.MinBathSelected = @"<option hidden value='4'>4 və daha çox</option>";
            }
            else
            {
                ViewBag.MinBathSelected = @$"<option hidden>{minBath}</option>";
            }

            #endregion


            if (Request.Cookies["card-items"] != null)
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


        public IActionResult Details(int id)
        {
            var model = new AnnouncesDetailsViewModel();

            model.Home = db.Homes
             .Where(h=>h.Id==id)
             .Include(h => h.Category)
             .Include(h => h.Images)
             .Include(h => h.Agent)
             .Include(h=>h.Owner)
             .Include(h=>h.Comments)
             .FirstOrDefault();

            model.Agent = db.Agents.Where(a=>a.Id!=model.Home.AgentId).OrderBy(a => Guid.NewGuid()).FirstOrDefault();

            model.Homes = db.Homes
             .Include(h => h.Category)
             .Include(h => h.Images)
             .Include(h => h.Agent)
             .Where(h=>h.Id!=id)
             .OrderBy(h => h.CreatedDate).Take(3).ToList();

            model.AppInfo = db.AppInfos.FirstOrDefault();


            model.Owners = db.Users.ToList();

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(int ownerId, int homeId, string name, string phone, string email, string message)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var owner = db.Users.FirstOrDefault(t => t.Id == ownerId);

                    var host = conf.GetValue<string>("emailAccount:smtpServer");
                    var port = conf.GetValue<int>("emailAccount:smtpPort");
                    var userName = conf.GetValue<string>("emailAccount:userName");
                    var password = conf.GetValue<string>("emailAccount:password");
                    //var cc = conf.GetValue<string>("emailAccount:cc")
                    //    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    SmtpClient client = new SmtpClient(host, port);
                    client.Credentials = new NetworkCredential(userName, password);
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage(userName, owner.Email);



                    mailMessage.Subject = "Evim Saytının müştərisindən";
                    mailMessage.Body = $"Göndərənin adı : {name} <br>" +
                        $"Göndərənin e-mail adresi : {email} <br>" +
                        $"Göndərənin telefon nömrəsi : {phone} <br>" +
                        $"Göndərənin Mesajı : {message}";
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);

                    //db.Entry(entity).State = EntityState.Modified;
                    //await _context.SaveChangesAsync();

                    TempData["message"] = "Gönderildi";

                    return RedirectToAction(nameof(Details), new { id = homeId });
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            TempData["message"] = "Xəta baş verdi. Zəhmət olmasa daha sonra göndərin";

            return RedirectToAction(nameof(Details), new { id = homeId });

        }


        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin,Admin,Client,Agent")]
        public async Task<IActionResult> CommentAdd(int homeId, string message)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (userId==null)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Daxil Olun"
                    });
                }

                var owner = db.Users.FirstOrDefault(a=>a.Id==int.Parse(userId));

                var home = db.Homes.FirstOrDefault(h => h.Id == homeId);

                home.Comments = new List<Comment>();
                
                var comment = new Comment
                {
                    Message=message,
                    OwnerId=int.Parse(userId),
                    HomeId= homeId
                };

                home.Comments.Add(comment);

                db.Update(home);
                await db.SaveChangesAsync();



                var date = comment.CreatedDate.ToString("dddd, dd MMMM yyyy");

                return Json(new
                {
                    error = false,
                    message = "Yorum elava olundu",
                    ownerName= owner.UserName,
                    date= date,
                    commentMesage=message
                });
            }

            return Json(new
            {
                error = true,
                message = "Xəta baş verdi"
            });
        }



    }
}
