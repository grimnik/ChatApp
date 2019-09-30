using LetsChat.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public class HomeMakeGroupViewModel
    {
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
      
        public bool Public { get; set; }
        public IFormFile Foto { get; set; }
    }
}
