using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class AnfragenListe : ITicketsystemRepository
    {
        //public static List<Anfrage> anfragenListe { get; set; } = new List<Anfrage>();

        private readonly AnwendungsDbContext _context;  // Neue variabel von Datenbank

        public static List<Anfrage> anfragenListe = new List<Anfrage>
        {
            new Anfrage{ KundenName= "Kunde1", Ansprechpartner = "Max Mustermann", Email="mustermann@gmail.com", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "dringend" },
            new Anfrage{ KundenName= "Kunde2", Ansprechpartner = "Julia Musterfrau", Email="musterfrau@gmail.com", DeadLine =new DateTime(2025,01,23), Erledigt= true, Kommentar= "3 Tage noch" },
            new Anfrage{ KundenName= "Kunde3", Ansprechpartner = "Erika Richter", Email="richter@gmx.de", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "bitte checken" },
            new Anfrage{ KundenName= "Kunde4", Ansprechpartner = "Wolfgang Bommes", Email="bommes@hotmail.com", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "" }
        };
        public AnfragenListe(AnwendungsDbContext context)  // Konstruktor 
        {
            _context = context;
            anfragenListe = _context.AnfrageDaten.ToList();
        }

        public List<Anfrage> GetAll()
        {
            return _context.AnfrageDaten.ToList();
        }

        public List<Anfrage> SortByName()
        { 
            return _context.AnfrageDaten.OrderBy(a => a.KundenName).ToList();
        }

        public List<Anfrage> SortByDate()
        {
            return _context.AnfrageDaten.OrderBy(a => a.DeadLine).ToList();
        }
        public Anfrage GetById(int id)
        {
            return _context.AnfrageDaten.Find(id);
        }
        public void Add(Anfrage anfrage)
        {
            _context.AnfrageDaten.Add(anfrage);
            anfragenListe.Add(anfrage);
            _context.SaveChanges();
        }
        public void Update(Anfrage anfrage)
        {
            _context.Update(anfrage);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var anfrage = _context.AnfrageDaten.Find(id);
            if (anfrage != null)
            {
                _context.AnfrageDaten.Remove(anfrage);
                anfragenListe.Remove(anfrage);
                _context.SaveChanges();
            }
        }
        public bool Exists(int id)
        {
            return _context.AnfrageDaten.Any(e => e.Id == id);
        }

       
    }
}
