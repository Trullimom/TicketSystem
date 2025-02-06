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
            new Anfrage{ KundenName= "Tech Solutions GmbH", ProjektName="AlphaConnect", Ansprechpartner = "Max Mustermann", Telefon= "+49 1523 4567890", Email="mustermann@techsolutions.de", Nachricht="Guten Morgen! ☕", DeadLine =new DateTime(2025,04,12), Erledigt= false, Kommentar= "dringend" },
            new Anfrage{ KundenName= "Musterbau AG", ProjektName="BauMasterX", Ansprechpartner = "Julia Musterfrau", Telefon= "+49 176 9876543", Email="musterfrau@musterbau.de", Nachricht="Wie ist der Stand? 📊", DeadLine =new DateTime(2025,06,18), Erledigt= true, Kommentar= "alles geklärt" },
            new Anfrage{ KundenName= "Innovatech GmbH", ProjektName="TechFlow", Ansprechpartner = "Erika Richter", Telefon= "+49 160 2345678", Email="richter@innovatech.com", Nachricht="Bitte um Feedback! 🔄", DeadLine =new DateTime(2025,05,05), Erledigt= false, Kommentar= "prüfen" },
            new Anfrage{ KundenName= "GreenEnergy Solutions", ProjektName="SolarBoost", Ansprechpartner = "Wolfgang Bommes", Telefon= "+49 172 8765432", Email="bommes@greenenergy.com", Nachricht="Kann das umgesetzt werden? 🚀", DeadLine =new DateTime(2025,07,01), Erledigt= false, Kommentar= "Rücksprache nötig" },
            new Anfrage{ KundenName= "FutureWeb AG", ProjektName="WebNextGen", Ansprechpartner = "Anna Schmidt", Telefon= "+49 1512 3456789", Email="anna.schmidt@futureweb.de", Nachricht="Freue mich drauf! 🎉", DeadLine =new DateTime(2025,06,10), Erledigt= false, Kommentar= "wichtig" },
            new Anfrage{ KundenName= "LogiTrans GmbH", ProjektName="CargoFlex", Ansprechpartner = "Markus Weber", Telefon= "+49 170 9871234", Email="markus.weber@logitrans.com", Nachricht="Alles klar! 👍", DeadLine =new DateTime(2025,07,05), Erledigt= true, Kommentar= "schon erledigt" },
            new Anfrage{ KundenName= "MediCare Solutions", ProjektName="MediTrack", Ansprechpartner = "Sophia Klein", Telefon= "+49 160 7654321", Email="sophia.klein@medicare.com", Nachricht="Ruf mich an! 📞", DeadLine =new DateTime(2025,03,15), Erledigt= false, Kommentar= "sehr dringend" },
            new Anfrage{ KundenName= "SmartHome Systems", ProjektName="HomeGuardian", Ansprechpartner = "Leon Fischer", Telefon= "+49 1520 4567890", Email="leon.fischer@smarthome.de", Nachricht="Lass uns das besprechen. 🤔", DeadLine =new DateTime(2025,09,01), Erledigt= false, Kommentar= "noch Zeit" },
            new Anfrage{ KundenName= "FoodTech GmbH", ProjektName="FreshTrack", Ansprechpartner = "Mia Hoffmann", Telefon= "+49 176 5432109", Email="mia.hoffmann@foodtech.com", Nachricht="Das klingt super! 😃", DeadLine =new DateTime(2025,08,20), Erledigt= true, Kommentar= "positiv" },
            new Anfrage{ KundenName= "AutoVision AG", ProjektName="DriveSync", Ansprechpartner = "Tom Berger", Telefon= "+49 170 3210987", Email="tom.berger@autovision.de", Nachricht="Melde mich später. ⏳", DeadLine =new DateTime(2025,05,30), Erledigt= false, Kommentar= "nicht vergessen" }
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

