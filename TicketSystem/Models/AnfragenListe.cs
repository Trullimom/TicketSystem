using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class AnfragenListe : ITicketsystemRepository
    {
        //public static List<Anfrage> anfragenListe { get; set; } = new List<Anfrage>();

        private readonly AnwendungsDbContext _context;  // Neue variabel von Datenbank
        public AnfragenListe(AnwendungsDbContext context)  // Konstruktor 
        {
            _context = context;
        }

        public List<Anfrage> GetAll()
        {
            return _context.AnfrageDaten.ToList();
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
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.AnfrageDaten.Any(e => e.Id == id);
        }
    }
}
