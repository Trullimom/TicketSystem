using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Models.Data;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ITicketsystemRepository _ticketsystemRepository;
        MitarbeiterDaten mitarbeiterDaten = new MitarbeiterDaten();

        public HomeController(ILogger<HomeController> logger, ITicketsystemRepository tsRepo)
        {
            _logger = logger;
            _ticketsystemRepository = tsRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Kontakt()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kontakt(Anfrage a)
        {
            //AnfragenListe.anfragenListe.Add(a);
            _ticketsystemRepository.Add(a);
            return View("Bestätigen", a);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckLogin(MitarbeiterDaten m)
        {
            string view = "";
            if (mitarbeiterDaten.IstLoginKorrekt(m))
            {
                if(mitarbeiterDaten.CheckRolle(m) == "admin")
                {
                    view = "Admin";
                }else if(mitarbeiterDaten.CheckRolle(m) == "mitarbeiter")
                {
                    view = "AnfragenTabelle";
                }
                return View(view, _ticketsystemRepository.GetAll());
            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult AnfragenTabelle()
        {
            return View(_ticketsystemRepository.GetAll());
        }

        //public IActionResult Erledigt(int id)
        //{
        //    //var anfrage = AnfragenListe.anfragenListe.FirstOrDefault(a => a.Id == id);
        //    //if (anfrage != null)
        //    //{
        //    //    anfrage.Erledigt = true;
        //    //}
        //    //return View("AnfragenTabelle", AnfragenListe.anfragenListe);
        //}

        [HttpGet]
        public IActionResult Kommentar(int Id)
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Kommentar(int Id, string kommentar)
        {
            Anfrage anfrage = _ticketsystemRepository.GetAll().Find(x => x.Id == Id);
            anfrage.Kommentar = kommentar;
            _ticketsystemRepository.Update(anfrage);
            return View(_ticketsystemRepository.GetAll());
        }
    }
}

