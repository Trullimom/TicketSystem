using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class MitarbeiterDaten 
    {
        
        public int Id { get; set; }

        public string Rolle { get; set; }

        [Required(ErrorMessage = "Username eingeben")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Passwort eingeben")]
        public string Passwort { get; set; }

        public string ViewName { get; set; } = String.Empty;

        public string? Vorname { get; set; } = String.Empty;

        public string? Nachname { get; set; } = String.Empty;

        public bool IstEingeloggt { get; set; } = false;

        public string VollerName { get; set; } = String.Empty;
        public DateTime? KommentierZeit { get; set; }



    }
}
