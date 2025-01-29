using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TicketSystem.Models;
using TicketSystem.Models.Data;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ITicketsystemRepository _ticketsystemRepository;
        //MitarbeiterDaten mitarbeiterDaten = new MitarbeiterDaten();
        private ILoginDatenRepository _loginDatenRepository;

        public static MitarbeiterDaten mitarbeiter = new MitarbeiterDaten();
        public static Anfrage anfrage = new Anfrage();
        public HomeController(ILogger<HomeController> logger, ITicketsystemRepository tsRepo, ILoginDatenRepository ldRepo)
        {
            _logger = logger;
            _ticketsystemRepository = tsRepo;
            _loginDatenRepository = ldRepo;
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
            _ticketsystemRepository.Add(a);
            return View("Best�tigen", a);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckLogin(MitarbeiterDaten m)
        {
            if (_loginDatenRepository.IstLoginKorrekt(m))
            {
                m.VollerName = MitarbeiterListe.CheckMitarbeiterName(m);
                //m.KommentierZeit = MitarbeiterListe.GetKommentarZeit(m);
                mitarbeiter = m;
                string view = _loginDatenRepository.CheckRolle(m);
                string controller = "";
                if (!ModelState.IsValid)
                {
                    m.IstEingeloggt = true;

                    if (view == "AnfragenTabelleAdmin")
                    {
                        controller = "Admin";
                    }
                    else
                    {
                        controller = "Home";
                    }

                }
                return RedirectToAction(view, controller, mitarbeiter);
            }
            else
            {
                return View("Login");
            }

        }

        public IActionResult AnfragenTabelle()
        {
            return View(mitarbeiter);
        }

        public IActionResult Erledigt(int id)
        {
            Anfrage anfrage = _ticketsystemRepository.GetAll().FirstOrDefault(a => a.Id == id);
            if (anfrage != null)
            {
                if (anfrage.Erledigt)
                {
                    anfrage.Erledigt = false;
                }
                else
                {
                    anfrage.Erledigt = true;
                }

                _ticketsystemRepository.Update(anfrage);
            }
            return View("Anfragentabelle", mitarbeiter);
        }

        [HttpGet]
        public IActionResult Kommentar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kommentar(int Id, string kommentar)
        {
            Anfrage anfrage = _ticketsystemRepository.GetAll().Find(x => x.Id == Id);
            anfrage.Kommentar = kommentar;
            anfrage.EingeloggterUser = mitarbeiter.VollerName;
            anfrage.KommentarZeit = DateTime.Now;
            _ticketsystemRepository.Update(anfrage);
            return View(anfrage);
        }

        public IActionResult SortierteAnfragenTabelle()
        {
            _ticketsystemRepository.SortByName();
            return View("Anfragentabelle", anfrage);
        }

        public IActionResult SortierteAnfragenTabelleDatum()
        {
            _ticketsystemRepository.SortByDate();
            return View("Anfragentabelle", anfrage);
        }
    }
}

