namespace TicketSystem.Models
{
    public class Anfrage
    {
        public int Id { get; set; }
        public string? KundenName { get; set; }

        public string? ProjektName { get; set; } = String.Empty;
        public string? NeuesProjekt { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Nachricht { get; set; }
        public string? Ansprechpartner { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public bool Erledigt { get; set; } = false;
        public DateTime DeadLine { get; set; } = DateTime.Today;
        public string? Kommentar { get; set; }
        public string? Mitarbeiter { get; set; }
        public static string? EingeloggterUser { get; set; }
        public string? KommentarUser { get; set; }
        public DateTime? KommentarZeit { get; set; }

        public List<string> TicketMitarbeiterListe { get; set; } = new List<string>();

    }
}


