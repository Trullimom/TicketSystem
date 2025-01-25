using TicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Models.Data
{
    public class LoginDbInitializer
    {
        public static void Initialize(AnwendungsDbContext context)
        {

            // Prüft ob Inhalte in der Datenbank vorhanden sind 
            if (context.LoginDaten.Any())
            {
                return; // DB wurde bereits gefüllt und wir verlassen diese Methode
            }

            var loginDaten = new MitarbeiterDaten[]
            {
                new MitarbeiterDaten { Rolle = "Admin", UserName = "adnmin", Passwort = "1111" },
                new MitarbeiterDaten { Rolle = "Admin", UserName = "adnmin1", Passwort = "1112" },
                new MitarbeiterDaten { Rolle = "Admin", UserName = "adnmin2", Passwort = "1113" },
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter", Passwort = "2222" },
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter1", Passwort = "2223" },
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter2", Passwort = "2224" },
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester", Passwort = "3333" },
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester1", Passwort = "3334" },
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester2", Passwort = "3335" },

            };

            context.LoginDaten.AddRange(loginDaten);
            context.SaveChanges();
        }
    }
}
