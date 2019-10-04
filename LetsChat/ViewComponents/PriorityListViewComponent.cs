using LetsChat.Data;
using LetsChat.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _appContext;
        public PriorityListViewComponent(ApplicationDbContext dbContext)
        {
            _appContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Name, byte[] Foto, string beschrijving)
        {
            var item = await GetItemAsync(Name, Foto, beschrijving);
            return View(item);
        }
        private Task<List<Groep>> GetItemAsync(string Name,byte[] Foto,string beschrijving)
        {
            return _appContext.Groepen.Where(x => x.Naam == Name && x.Foto == Foto && x.Beschrijving == beschrijving).ToListAsync();
        }
    }
}
