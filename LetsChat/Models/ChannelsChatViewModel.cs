using LetsChat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public class ChannelsChatViewModel : BaseViewModel
    {
        public Channel Channel { get; set; }
        public string Message { get; set; }
    }
}
