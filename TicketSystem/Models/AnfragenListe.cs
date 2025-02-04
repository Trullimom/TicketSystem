using TicketSystem.Models.Data;


namespace TicketSystem.Models
{
    public class AnfragenListe : ITicketsystemRepository
    {
        //public static List<Anfrage> anfragenListe { get; set; } = new List<Anfrage>();

        private readonly AnwendungsDbContext _context;  // Neue variabel von Datenbank
        public static List<string> DistinctProjekt { get; set; } = new List<string>();
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
        public static List<string> GetProjekteNamen()
        {
           
            var projektListe = (from c in anfragenListe
                            select c.ProjektName.Trim().Replace(" ", ""))
                .Distinct() 
                .OrderBy(x => x).OrderBy(x=>x.Length);
            var list = projektListe.ToList();
            return list;
        }
        public List<Anfrage> SortByName()
        {
            List<Anfrage> tempList = _context.AnfrageDaten.OrderBy(a => a.ProjektName).ToList();
            anfragenListe = tempList;
            return tempList;
        }

        public List<Anfrage> SortByDate()
        {
            List<Anfrage> tempList = _context.AnfrageDaten.OrderBy(a => a.DeadLine).ToList();
            anfragenListe = tempList;
            return tempList;
        }
        public Anfrage GetById(int id)
        {
            return _context.AnfrageDaten.Find(id);
        }
        public void Add(Anfrage anfrage)
        {
            _context.AnfrageDaten.Add(anfrage);
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

        public void AddToProject(MitarbeiterDaten m)
        {
            Anfrage anfrage = new Anfrage();
            anfrage.TicketMitarbeiterListe.Add(m.VollerName);
            _context.LoginDaten.Add(m);
            _context.SaveChanges();
        }

      
    }
}

