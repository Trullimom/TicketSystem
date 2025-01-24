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
            new Anfrage{ KundenName= "Kunde1", MitarbeiterName = "Andre", Email="asda", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "blablabla" },
            new Anfrage{ KundenName= "Kunde2", MitarbeiterName = "Jihye", Email="asda", DeadLine =new DateTime(2025,01,23), Erledigt= true, Kommentar= "blablabla" },
            new Anfrage{ KundenName= "Kunde3", MitarbeiterName = "Marcel", Email="asda", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "blablabla" },
            new Anfrage{ KundenName= "Kunde4", MitarbeiterName = "Abdullah", Email="asda", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "blablabla" }
        };


        // Daten abspeichern also die Datenbank mehr oder weniger darauf vorbereiten diese Daten abzuspeicher.
        context.AnfrageDaten.AddRange(anfragen);

        // Dieser Befehl speichert letztendlich die Daten auch in der Datenbank. 
        // Dieser Befehil MUSS am ausgeführt werden. 
        context.SaveChanges();
    }
}
