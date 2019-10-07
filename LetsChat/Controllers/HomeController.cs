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
using Microsoft.AspNetCore.Authorization;

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
            HomeGroupPlanelViewModel model = new HomeGroupPlanelViewModel();
            BaseViewModel vm = MakeSideList(model);
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
        [Authorize]

        public IActionResult MakeGroup()
        {
            return View();
        }
        [Authorize]
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
        [Authorize]
        public IActionResult Channels(int id)
        {
            ChannelHomeViewModel model = new ChannelHomeViewModel();
            List<GroepChannel> groepChannel = _appContext.GroepChannels.Where(a => a.GroepId == id).ToList();
            foreach (var item in groepChannel)
            {
               model.Channels = _appContext.Channels.Where(a => a.Id == item.ChannelId).ToList();
                
                
            }
            BaseViewModel vm = MakeSideList(model);
            
            model.SelectedGroup = id;
            return View(vm);
        }
        public BaseViewModel MakeSideList(BaseViewModel model)
        {
            List<Groep> groepenFromDb = _appContext.Groepen.ToList();
            List<Groep> groepen = new List<Groep>();
            List<int> Id = new List<int>();
            BaseViewModel vm = model;
            foreach (var item in groepenFromDb)
            {
                Id.Add(item.Id);
            }
            vm.Id = Id;
            foreach (var item in groepenFromDb)
            {
                groepen.Add(item);
            }
            vm.Groepen = groepen;

            return vm;
        }
       
        
    }
}
