using LetsChat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public class HomeGroupPlanelViewModel
    {
        public List<int> Id { get; set; }
        public virtual List<Groep> Groepen { get; set; }
        public virtual List<Channel> Channels { get; set; }
    }
}
