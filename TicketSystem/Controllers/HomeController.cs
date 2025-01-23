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

        public IActionResult Kommentar(int Id)
        {
            Console.WriteLine(Id);
            return View();
        }

    }
}
