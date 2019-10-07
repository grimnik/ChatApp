using LetsChat.Data;
using LetsChat.Domain;
using LetsChat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LetsChat.Controllers
{
    [Authorize]

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
        [Authorize]

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
        [Authorize]

        public IActionResult Chat(int id)
        {
            HomeController home = new HomeController(_appContext);
            ChannelsChatViewModel model = new ChannelsChatViewModel();
            model.ChannelId = id;
            model.Messages = _appContext.Messages.Include(u => u.User).Where(m => m.Channel.Id == id).ToList();
           
            BaseViewModel vm = home.MakeSideList(model);

            return View(vm);
        }
        [HttpPost]
        [Authorize]
        public IActionResult PostMessage(ChannelsChatViewModel model,int id)
        {
           var user = _appContext.Users.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
           
            _appContext.Messages.Add(new Message()
            {
                Channel = _appContext.Channels.FirstOrDefault(c => c.Id == id),
                User = user,
                ChatMessage = model.Message
            });
            _appContext.SaveChanges();
            return RedirectToAction("Chat",new{id = id }
            );
        }
    }
}
