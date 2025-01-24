using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MitarbeiterDaten mitarbeiterDaten = new MitarbeiterDaten();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            AnfragenListe.anfragenListe.Add(a);
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
            if (mitarbeiterDaten.IstLoginKorrekt(m))
            {
                return View("AnfragenTabelle");
            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult AnfragenTabelle()
        {
            return View();
        }

        public IActionResult Erledigt(int id)
        {
            var anfrage = AnfragenListe.anfragenListe.FirstOrDefault(a => a.Id == id);
            if (anfrage != null)
            {
                anfrage.Erledigt = true;
            }
            return View("AnfragenTabelle", AnfragenListe.anfragenListe);
        }

        [HttpGet]
        public IActionResult Kommentar(int Id)
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Kommentar(int Id, string kommentar)
        {
            Anfrage anfrage = AnfragenListe.anfragenListe.Find(x => x.Id == Id);
            anfrage.Kommentar = kommentar;
            return View();
        }
    }
}

