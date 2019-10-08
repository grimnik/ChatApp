using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Domain
{
    public class Groep
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Channel> Channels { get; set; }
        public bool Public { get; set; }
        public string Beschrijving { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public byte[] Foto { get; set; }
    }
}
