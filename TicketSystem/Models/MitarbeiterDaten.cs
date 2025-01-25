using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class MitarbeiterDaten 
    {
        public static int countId = 0;
        public int  Id { get; set; }

        public string Rolle { get; set; }

        public string UserName { get; set; }

        public string Passwort { get; set; }

        public string ViewName { get; set; } = String.Empty;

        //public static Dictionary<string, string> LoginDaten = new Dictionary<string, string>
        //{
        //    { "admin", "1111"},
        //    { "mitarbeiter", "2222"},
        //    { "tester", "3333"}

        //};
       
        public MitarbeiterDaten()
        {
            
        }

       

    }
}
