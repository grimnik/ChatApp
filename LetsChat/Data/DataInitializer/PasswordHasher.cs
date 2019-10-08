using LetsChat.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LetsChat.Data.DataInitializer
{
    internal class PasswordHasher : PasswordHasher<ApplicationUser>
    {
        public PasswordHasher(IOptions<PasswordHasherOptions> optionsAccessor = null) : base(optionsAccessor)
        {
        }
    }
}