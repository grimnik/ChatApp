using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public IdentityUser User { get; set; }
        public string ChatMessage { get; set; }
    }
}
