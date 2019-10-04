using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Domain
{
    public class GroepChannel
    {
        public int Id { get; set; }
        public int GroepId { get; set; }
        public int ChannelId { get; set; }
    }
}
