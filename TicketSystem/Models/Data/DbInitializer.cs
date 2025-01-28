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
            new Anfrage{ KundenName= "Kunde1", ProjektName="Projekt1", Ansprechpartner = "Max Mustermann", Email="mustermann@gmail.com", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "dringend" },
            new Anfrage{ KundenName= "Kunde2", ProjektName="Projekt2", Ansprechpartner = "Julia Musterfrau", Email="musterfrau@gmail.com", DeadLine =new DateTime(2025,01,23), Erledigt= true, Kommentar= "3 Tage noch" },
            new Anfrage{ KundenName= "Kunde3", ProjektName="Projekt3", Ansprechpartner = "Erika Richter", Email="richter@gmx.de", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "bitte checken" },
            new Anfrage{ KundenName= "Kunde4", ProjektName="Projekt4", Ansprechpartner = "Wolfgang Bommes", Email="bommes@hotmail.com", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "" }
        };


        // Daten abspeichern also die Datenbank mehr oder weniger darauf vorbereiten diese Daten abzuspeicher.
        context.AnfrageDaten.AddRange(anfragen);

        // Dieser Befehl speichert letztendlich die Daten auch in der Datenbank. 
        // Dieser Befehil MUSS am ausgeführt werden. 
        context.SaveChanges();
    }
}
