﻿using FinalNew.Models.DataContext;
using FinalNew.Models.Entity;
using FinalNew.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinalNew.Controllers
{
    [AllowAnonymous]
    public class AgentController : Controller
    {
        readonly HomeSaleDbContext db;
        readonly IConfiguration conf;


        public AgentController(HomeSaleDbContext db, IConfiguration conf)
        {
            this.db = db;
            this.conf = conf;
        }

        public IActionResult Index()
        {
            var agents = db.Agents.ToList();
            return View(agents);
        }

        public IActionResult Details(int id)
        {
            var model = new AgentViewModel();

            model.Agent = db.Agents.Where(a => a.Id == id).FirstOrDefault();

                model.Homes = db.Homes
              .Include(h => h.Category)
              .Include(h => h.Images)
              .Where(h => h.AgentId == id)
              .ToList();
            

            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");

            var cities = db.Cities.OrderBy(a => a.Id);

            ViewData["CityId"] = new SelectList(cities, "Id", "Name");

            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name");

            ViewBag.AnnounceTypeSelected = "Sale";

            return View(model);
        }

        [HttpPost]
        public IActionResult Details(string announceType, int categoryId, int cityId, int metroId,
             int minPrice, int maxPrice, int minArea, int maxArea, int minRoom, int minBath, int agentId)
        {

            var model = new AgentViewModel();

            model.Homes = db.Homes
            .Include(h => h.Category)
            .Include(h => h.Metro)
            .Include(h => h.City)
            .Include(h => h.Images)
            .Where(h => h.AgentId == agentId)
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

            model.Agent = db.Agents.Where(a => a.Id == agentId).FirstOrDefault();

            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name",categoryId);

            var cities = db.Cities.OrderBy(a => a.Id);

            ViewData["CityId"] = new SelectList(cities, "Id", "Name",cityId);

            ViewData["MetroId"] = new SelectList(db.Metros, "Id", "Name",metroId);



            #region Selected items

            if (announceType == null || announceType == "")
            {
                ViewBag.AnnounceTypeSelected = "Sale";
            }
            else
            {
                ViewBag.AnnounceTypeSelected = announceType;
            }


            if (minPrice == 0)
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

            return View(model);
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(int agentId,string name,string email,string message)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var agent = db.Agents.FirstOrDefault(t => t.Id == agentId);

                    var host = conf.GetValue<string>("emailAccount:smtpServer");
                    var port = conf.GetValue<int>("emailAccount:smtpPort");
                    var userName = conf.GetValue<string>("emailAccount:userName");
                    var password = conf.GetValue<string>("emailAccount:password");
                    //var cc = conf.GetValue<string>("emailAccount:cc")
                    //    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    SmtpClient client = new SmtpClient(host, port);
                    client.Credentials = new NetworkCredential(userName, password);
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage(userName, agent.Email);



                    mailMessage.Subject = "Evim Saytının müştərisindən";
                    mailMessage.Body = $"Müştərinin e-mail adresi : {email} <br>" +
                        $"Müştərinin adı : {name} <br>" +
                        $"Müştərinin Mesajı : {message}";
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);

                    //db.Entry(entity).State = EntityState.Modified;
                    //await _context.SaveChangesAsync();

                    TempData["message"] = "Gönderildi";

                    return RedirectToAction(nameof(Details),new { id=agentId});
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            TempData["message"] = "Xəta baş verdi. Zəhmət olmasa daha sonra göndərin";

            return RedirectToAction(nameof(Details), new { id = agentId });

        }


    }

}
