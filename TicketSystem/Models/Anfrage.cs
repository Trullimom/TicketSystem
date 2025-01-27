﻿namespace TicketSystem.Models
{
    public class Anfrage
    {
        public int Id { get; set; }
        public string? KundenName { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Nachricht { get; set; }
        public string? MitarbeiterName { get; set; }
        public DateTime? Datum { get; set; }
        public bool Erledigt { get; set; } = false;
        public DateTime DeadLine { get; set; }
        public string? Kommentar { get; set; }

        
    }
}


