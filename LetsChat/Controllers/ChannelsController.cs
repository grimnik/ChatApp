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
        public readonly UserManager<ApplicationUser> _userManager;
        public ChannelsController(ApplicationDbContext applicationDb, UserManager<ApplicationUser> userManager)
        {
            _appContext = applicationDb;
            _userManager = userManager;
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

        public async Task<IActionResult> Chat(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            var messages = await _appContext.Messages.ToListAsync();
            HomeController home = new HomeController(_appContext);
            ChannelsChatViewModel model = new ChannelsChatViewModel();
            model.ChannelId = id;
            model.Messages = _appContext.Messages.Include(u => u.User).Where(m => m.Channel.Id == id).ToList();
           
            BaseViewModel vm = home.MakeSideList(model);

            return View(vm);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostMessage(ChannelsChatViewModel model,int id)
        {
            if (ModelState.IsValid)
            {

            ///*message.User.UserName*/ = User.Identity.Name;
            var sender = await _userManager.GetUserAsync(User);
                //message.User.Id = sender.Id;
                await _appContext.Messages.AddAsync(new Message()
                {
                    ChatMessage = model.Message,
                    User = sender,
                    Channel = _appContext.Channels.FirstOrDefault(c => c.Id == id)
                });
                await _appContext.SaveChangesAsync();
               
            }
                return RedirectToAction("Chat", new { id = id }

           
            
            );
        }
    }
}
