using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] Avatar { get; set; }
    }
}
