using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public class HomeGroupPlanelViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }

        public bool Public { get; set; }
        public byte[] Foto { get; set; }
    }
}
