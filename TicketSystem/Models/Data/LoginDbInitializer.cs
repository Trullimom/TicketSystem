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
                new MitarbeiterDaten { Rolle = "CodingCat", UserName = "admin", Passwort = "1111", Vorname = "Jihye", Nachname = "Lee"},
                new MitarbeiterDaten { Rolle = "Azubi", UserName = "admin1", Passwort = "1112", Vorname = "Abdullah", Nachname = "Hemmat"},
                new MitarbeiterDaten { Rolle = "UI/UX Deisigner", UserName = "admin2", Passwort = "1113", Vorname = "Marcel", Nachname = "Kutzmutz"},
                new MitarbeiterDaten { Rolle = "Chef", UserName = "mitarbeiter", Passwort = "2222", Vorname = "Andre", Nachname = "Schnitzke"},
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter1", Passwort = "2223", Vorname = "Andreas", Nachname = "Schneider"},
                new MitarbeiterDaten { Rolle = "Mitarbeiter", UserName = "mitarbeiter2", Passwort = "2224", Vorname = "Hamza", Nachname = "Bensalem"},
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester", Passwort = "3333", Vorname = "Maximilian", Nachname = "Pagels"},
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester1", Passwort = "3334", Vorname = "Yannick", Nachname = "Stuhl"},
                new MitarbeiterDaten { Rolle = "Tester", UserName = "tester2", Passwort = "3335", Vorname = "Cemre", Nachname = "Yumruk"},

            };

            context.LoginDaten.AddRange(loginDaten);
            context.SaveChanges();
        }
    }
}
