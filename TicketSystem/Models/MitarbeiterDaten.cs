using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class MitarbeiterDaten 
    {

        public int Id { get; set; }

        public string Rolle { get; set; }

        public string UserName { get; set; }

        public string Passwort { get; set; }

        public string ViewName { get; set; } = String.Empty;

        public string Vorname { get; set; } = String.Empty;

        public string Nachname { get; set; } = String.Empty;

        public MitarbeiterDaten()
        {
            
        }

       

    }
}
