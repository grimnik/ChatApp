using LetsChat.Data;
using LetsChat.Domain;
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
        public IActionResult CreateChannel(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateChannel(ChannelsCreateViewModel model,int id)
        {

           _appContext.Channels.Add(new Domain.Channel()
            {
                Naam = model.Naam,
                
            });
            _appContext.SaveChanges();
            var channel = _appContext.Channels.FirstOrDefault(a => a.Naam == model.Naam);
            _appContext.GroepChannels.Add(new Domain.GroepChannel()
            {
                GroepId = id,
                ChannelId = channel.Id
            });
            _appContext.SaveChanges();
            return RedirectToAction("Channels","Home");
        }
        public IActionResult Chat(int id)
        {
            HomeController home = new HomeController(_appContext);
            ChannelsChatViewModel model = new ChannelsChatViewModel();

            BaseViewModel vm = home.MakeSideList(model);
            return View(vm);
        }
        public IActionResult PostMessage(ChannelsChatViewModel model,int id)
        {
            return View();
        }
    }
}
