using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using System.Diagnostics.Eventing.Reader;

namespace TicketSystem.Models
{
    public class MitarbeiterDaten
    {
        public static int countId = 0;
        public int  Id { get; set; }

        public string Rolle { get; set; }

        public string UserName { get; set; }

        public string Passwort { get; set; }

        public static Dictionary<string, string> LoginDaten = new Dictionary<string, string>
        {
            { "admin", "1111"},
            { "mitarbeiter", "2222"},
            { "tester", "3333"}

        };

        public MitarbeiterDaten()
        {
            Id = countId;
            countId++;
        }

        public string CheckRolle(MitarbeiterDaten m)
        {
            if(m.UserName == "admin")
            {
                Rolle = "admin";
            }else if(m.UserName == "mitarbeiter")
            {
                Rolle = "mitarbeiter";
            }
            else
            {
                Rolle = "tester";
            }
            return Rolle;
        }
        public bool IstLoginKorrekt(MitarbeiterDaten m)
        {
            foreach(var daten in LoginDaten)
            {
                if(daten.Key == m.UserName && daten.Value == m.Passwort)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
