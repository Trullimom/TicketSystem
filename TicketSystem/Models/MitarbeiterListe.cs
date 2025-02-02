using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class MitarbeiterListe : ILoginDatenRepository
    {
        private readonly AnwendungsDbContext _context;

        public static List<MitarbeiterDaten> ListMitarbeiter = new List<MitarbeiterDaten>()
        {
             new MitarbeiterDaten { Rolle = "CodingCat", UserName = "admin", Passwort = "1111", Vorname = "Jihye", Nachname = "Lee"},
                new MitarbeiterDaten { Rolle = "Azubi", UserName = "admin1", Passwort = "1112", Vorname = "Abdullah", Nachname = "Hemmat"},
                new MitarbeiterDaten { Rolle = "UI/UX Deisigner", UserName = "admin2", Passwort = "1113", Vorname = "Marcel", Nachname = "Kutzmutz"},
                new MitarbeiterDaten { Rolle = "Chef", UserName = "mitarbeiter", Passwort = "2222", Vorname = "Andre", Nachname = "Schnitzke"},
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter1", Passwort = "2223", Vorname = "Andreas", Nachname = "Schneider"},
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter2", Passwort = "2224", Vorname = "Hamza", Nachname = "Bensalem"},
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester", Passwort = "3333", Vorname = "Maximilian", Nachname = "Pagels"},
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester1", Passwort = "3334", Vorname = "Yannick", Nachname = "Stuhl"},
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester2", Passwort = "3335", Vorname = "Cemre", Nachname = "Yumruk"},

        };
        public MitarbeiterListe(AnwendungsDbContext context)
        {
            _context = context;
            ListMitarbeiter = _context.LoginDaten.ToList();

        }

        public List<MitarbeiterDaten> GetAll()
        {
            return _context.LoginDaten.ToList();
        }
        public static DateTime GetKommentarZeit(MitarbeiterDaten m)
        {
            DateTime zeit = new DateTime();
            foreach(var md in ListMitarbeiter)
            {
                if(m.UserName == md.UserName)
                {
                    zeit = DateTime.Now;
                    break;
                }
            }
            return zeit;
        }

        public static string CheckMitarbeiterName(MitarbeiterDaten m)
        {
            string name = "";
            foreach (var md in ListMitarbeiter)
            {
                if (m.UserName == md.UserName)
                {
                    name = md.Nachname + ", " + md.Vorname;
                    break;
                }
            }
            return name;
        }

        public static string GetVornameLogin(MitarbeiterDaten m)
        {
            string name = "";
            foreach (var md in ListMitarbeiter)
            {
                if (m.UserName == md.UserName)
                {
                    name = md.Vorname;
                    break;
                }
            }
            return name;
        }
        public string CheckRolle(MitarbeiterDaten m)
        {
            if (m.UserName.StartsWith("admin"))
            {
                m.Rolle = "Admin";
                m.ViewName = "AnfragenTabelleAdmin";
            }
            else
            {
                m.ViewName = "AnfragenTabelle";
            }
            return m.ViewName;
        }
        public bool IstLoginKorrekt(MitarbeiterDaten m)
        {
            foreach (var daten in _context.LoginDaten)
            {
                if (daten.UserName == m.UserName && daten.Passwort == m.Passwort)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(MitarbeiterDaten md)
        {
            _context.LoginDaten.Add(md);
            ListMitarbeiter.Add(md);
            _context.SaveChanges();
        }

        

        public void Delete(int id)
        {
            var mitarbeiter = _context.LoginDaten.Find(id);
            if (mitarbeiter != null)
            {
                _context.LoginDaten.Remove(mitarbeiter);
                ListMitarbeiter.Remove(mitarbeiter);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.LoginDaten.Any(m => m.Id == id);
        }

        public void Update(MitarbeiterDaten mitarbeiter)
        {
            _context.Update(mitarbeiter);
            _context.SaveChanges();
        }

        public MitarbeiterDaten GetById(int id)
        {
            return _context.LoginDaten.Find(id);
        }

     



    }
    }
