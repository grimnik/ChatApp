using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsChat.Domain;

namespace LetsChat.Models
{
    public class ChannelHomeViewModel : BaseViewModel
    {
        public int SelectedGroup { get; set; }
        public List<Channel> Channels { get; set; }
    }
}
