namespace TicketSystem.Models.Data
{
    public interface ILoginDatenRepository
    {
        List<MitarbeiterDaten> GetAll();
        MitarbeiterDaten GetById(int id);
        void Add(MitarbeiterDaten mitarbeiter);
        void Delete(int id);
        bool Exists(int id);
        bool IstLoginKorrekt(MitarbeiterDaten mitarbeiter);
        string CheckRolle(MitarbeiterDaten mitarbeiter);
    }
}
