

using LetsChat.Data;
using LetsChat.Domain;
using LetsChat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Hubs
{
    public class ChatHub : Hub
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public ApplicationDbContext _appContext { get; set; }
        public ChatHub(ApplicationDbContext applicationDb, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }
        public async Task SendMessage(string user, string message)
        {
           
            await Clients.All.SendAsync("recieveMessage", user, message);
        }
    }
}
