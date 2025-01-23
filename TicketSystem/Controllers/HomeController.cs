using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Kontakt(Anfrage a)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kontakt(Anfrage a, int x)
        {
            AnfragenListe.anfragenListe.Add(a);
            return View("Bestätigen", a);
        }
        [HttpGet]
        public IActionResult Login(MitarbeiterDaten m)
        {
            return View(m);
        }
        [HttpPost]
        public IActionResult Login(MitarbeiterDaten m, int x)
        {
            return View();
        }

        bool IstRichtig;
        public IActionResult CheckLogin(MitarbeiterDaten m)
        {
           
            foreach(var daten in MitarbeiterDaten.LoginDaten)
            {
                if (m.UserName == daten.Key && m.Passwort == daten.Value)
                {
                    IstRichtig = true;
                    break;
                }
                else
                {
                    IstRichtig = false;
                }
            }
            if (IstRichtig)
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

    }
}
