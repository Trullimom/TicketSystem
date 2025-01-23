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

            //if (Rolle==Tester)
            //{
            //    Console.WriteLine("hier ist der Tester");
            //}
            //else if(Rolle== Admin)
            //{
            //    Console.WriteLine("hier ist der Admin ");
            //}else
            //{
            //    Console.WriteLine("Hier ist ein Mitarbeiter");
            //}
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
