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
        IList<Groep> Groeps;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
            Groeps = new List<Groep>();
            
        }
        public IActionResult Index()
        {
            HomeGroupPlanelViewModel vm = MakeSideList();
            return View(vm);
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

            return RedirectToAction("Index");
        }
        public IActionResult Channels(int Id)
        {
            HomeGroupPlanelViewModel vm = MakeSideList();
            return View(vm);
        }
        public HomeGroupPlanelViewModel MakeSideList()
        {
            List<Groep> groepenFromDb = _appContext.Groepen.ToList();
            List<Groep> groepen = new List<Groep>();
            HomeGroupPlanelViewModel vm = new HomeGroupPlanelViewModel();

            foreach (var item in groepenFromDb)
            {
                groepen.Add(item);
            }
            vm.Groepen = groepen;

            return vm;
        }
       
        
    }
}
