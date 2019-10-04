using LetsChat.Data;
using LetsChat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace LetsChat.Controllers
{
    public class ChannelsController : Controller
    {
        public ApplicationDbContext _appContext { get; set; }
        public ChannelsController(ApplicationDbContext applicationDb)
        {
            _appContext = applicationDb;
        }
        public IActionResult CreateChannel()
        {
            return View();
        }
        public IActionResult CreateChannel(ChannelsCreateViewModel model)
        {

            _appContext.Channels.Add(new Domain.Channel()
            {
                Naam = model.Naam
            });
            _appContext.SaveChanges();
            return RedirectToAction("Channels","Home");
        }
    }
}
