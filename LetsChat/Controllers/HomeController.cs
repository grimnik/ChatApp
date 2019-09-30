using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetsChat.Models;
using LetsChat.Data;
using LetsChat.Domain;
using System.IO;

namespace LetsChat.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _appContext { get; set; }

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult MakeGroup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeGroup(HomeMakeGroupViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            var groep = new Groep()
            {
                Naam = model.Naam,
                Beschrijving = model.Beschrijving,
                Public = model.Public,

            };
            using(var memoryStream = new MemoryStream())
            {
                 model.Foto.CopyTo(memoryStream);
                groep.Foto = memoryStream.ToArray();

            }
            _appContext.Groepen.Add(groep);
            _appContext.SaveChanges();

            return View("Index");
        }
        public IActionResult GroupList()
        {
            IEnumerable<Groep> groepenFromDb = _appContext.Groepen.ToArray();
            List<HomeGroupPlanelViewModel> model = new List<HomeGroupPlanelViewModel>();
            foreach (var item in groepenFromDb)
            {
                model.Add(new HomeGroupPlanelViewModel()
                {
                    Id = item.Id,
                    Naam = item.Naam,
                    Beschrijving = item.Beschrijving,
                    Foto = item.Foto,
                    Public = item.Public
                });
            }
            return PartialView(model);
        }
    }
}
