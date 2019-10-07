using LetsChat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public class ChannelsChatViewModel : BaseViewModel
    {
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
        public ICollection<Message> Messages { get; set; }
        public string Message { get; set; }
    }
}
