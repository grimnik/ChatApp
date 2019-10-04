using LetsChat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public abstract class BaseViewModel
    {
        public List<int> Id { get; set; }
        public List<Groep> Groepen { get; set; }
    }
}
