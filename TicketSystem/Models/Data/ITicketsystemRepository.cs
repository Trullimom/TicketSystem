using TicketSystem.Models;

namespace TicketSystem.Models.Data
{
    public interface ITicketsystemRepository
    {
        List<Anfrage> GetAll();
        List<Anfrage> SortByName();
        List<Anfrage> SortByDate();
        Anfrage GetById(int id);
        void Add(Anfrage model);
        void Update(Anfrage model);
        void Delete(int id);
        bool Exists(int id);
        public void AddToProject(MitarbeiterDaten m);
    }
}
