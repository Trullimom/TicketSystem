using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Models.Data;

namespace TicketSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ITicketsystemRepository _ticketsystemRepository;
        //MitarbeiterDaten mitarbeiterDaten = new MitarbeiterDaten();
        private ILoginDatenRepository _loginDatenRepository;
        private static MitarbeiterDaten mitarbeiter = new MitarbeiterDaten();
        public AdminController(ILogger<HomeController> logger, ITicketsystemRepository tsRepo, ILoginDatenRepository ldRepo)
        {
            _logger = logger;
            _ticketsystemRepository = tsRepo;
            _loginDatenRepository = ldRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

    
        public IActionResult AnfragentabelleAdmin()
        {
            return View(HomeController.mitarbeiter);
        }

        public IActionResult SortierteAnfragenTabelle()
        {
            return View("AnfragentabelleAdmin", _ticketsystemRepository.SortByName());
        }

        public IActionResult SortierteAnfragenTabelleDatum()
        {
            return View("AnfragentabelleAdmin", _ticketsystemRepository.SortByDate());
        }

        [HttpGet]
        public IActionResult AddTicket()
        {
            return View("Formular");
        }
        [HttpPost]
        public IActionResult AddTicket(Anfrage a)
        {
            _ticketsystemRepository.Add(a);
            AnfragenListe.anfragenListe.Add(a);
            return View("AnfragenTabelleAdmin", _ticketsystemRepository.GetAll());
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
            return View("AnfragenTabelleAdmin", _ticketsystemRepository.GetAll());
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
            anfrage.EingeloggterUser = HomeController.mitarbeiter.VollerName;
            _ticketsystemRepository.Update(anfrage);
            return View(anfrage);
        }

        [HttpPost]
        public IActionResult Löschen(int id)
        {
            _ticketsystemRepository.Delete(id);
            return View("AnfragenTabelleAdmin", _ticketsystemRepository.GetAll());
        }

        [HttpGet]
        public IActionResult AddMitarbeiter()
        {
            return View("MitarbeiterFormular");
        }

        [HttpPost]
        public IActionResult AddMitarbeiter(MitarbeiterDaten m)
        {
            _loginDatenRepository.Add(m);
            return View("MitarbeiterTabelle", _loginDatenRepository.GetAll());
        }
        public IActionResult MitarbeiterTabelle()
        {
            return View(_loginDatenRepository.GetAll());
        }
        [HttpPost]
        public IActionResult DeleteMitarbeiter(int id)
        {
            _loginDatenRepository.Delete(id);
            return View("MitarbeiterTabelle", _loginDatenRepository.GetAll());

        }

        [HttpGet]
        public IActionResult Mitarbeiter()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Mitarbeiter(int Id, MitarbeiterDaten md)
        {
            Anfrage anfrage = _ticketsystemRepository.GetAll().Find(x => x.Id == Id);
            anfrage.EingeloggterUser = md.VollerName;
            anfrage.EingeloggterUser = mitarbeiter.VollerName;
            _ticketsystemRepository.Update(anfrage);
            return View("AnfragenTabelleAdmin", _ticketsystemRepository.GetAll());
        }
    }
}
