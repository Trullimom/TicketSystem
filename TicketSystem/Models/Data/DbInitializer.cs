namespace TicketSystem.Models.Data;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{
    public static void Initialize(AnwendungsDbContext context)
    {


        // Prüft ob Inhalte in der Datenbank vorhanden sind 
        if (context.AnfrageDaten.Any())
        {
            return; // DB wurde bereits gefüllt und wir verlassen diese Methode
        }


        // Neue BlogPosts als Array anlegen.
        var anfragen = new Anfrage[]
        {
            new Anfrage{ KundenName= "Kunde1", Ansprechpartner = "Max Mustermann",Telefon= "+49 1523 4567890", Email="mustermann@gmail.com",Nachricht="Hey, wie geht’s? 😊", DeadLine =new DateTime(2025,03,23), Erledigt= false, Kommentar= "dringend" },
            new Anfrage{ KundenName= "Kunde2", Ansprechpartner = "Julia Musterfrau", Telefon= "+49 176 9876543", Email="musterfrau@gmail.com",Nachricht="Komm gut heim! 🚗💨", DeadLine =new DateTime(2025,05,25), Erledigt= true, Kommentar= "3 Tage noch" },
            new Anfrage{ KundenName= "Kunde3", Ansprechpartner = "Erika Richter", Telefon= "+49 160 2345678", Email="richter@gmx.de", Nachricht="Denke an dich! ❤️",DeadLine =new DateTime(2025,04,01), Erledigt= false, Kommentar= "bitte checken" },
            new Anfrage{ KundenName= "Kunde4", Ansprechpartner = "Wolfgang Bommes", Telefon= "+49 172 8765432", Email="bommes@hotmail.com",Nachricht="Bis gleich! 👋", DeadLine =new DateTime(2025,04,20), Erledigt= false, Kommentar= "" }
        };


        // Daten abspeichern also die Datenbank mehr oder weniger darauf vorbereiten diese Daten abzuspeicher.
        context.AnfrageDaten.AddRange(anfragen);

        // Dieser Befehl speichert letztendlich die Daten auch in der Datenbank. 
        // Dieser Befehil MUSS am ausgeführt werden. 
        context.SaveChanges();
    }
}
