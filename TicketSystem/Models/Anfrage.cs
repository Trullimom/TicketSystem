namespace TicketSystem.Models
{
    public class Anfrage
    {
        public int Id { get; set; }
        public string? KundenName { get; set; }

        public string? ProjektName { get; set; }
        public string? NeuesProjekt { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Nachricht { get; set; }
        public string? Ansprechpartner { get; set; }
        public DateTime? Datum { get; set; }
        public bool Erledigt { get; set; } = false;
        public DateTime DeadLine { get; set; }
        public string? Kommentar { get; set; }
        public string? Mitarbeiter { get; set; }
        public string? EingeloggterUser { get; set; }
        public DateTime? KommentarZeit { get; set; }

        public List<string> TicketMitarbeiterListe { get; set; } = new List<string>();

    }
}


