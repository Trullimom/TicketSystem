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
            new Anfrage{ KundenName= "Tech Solutions GmbH", ProjektName="AlphaConnect", Ansprechpartner = "Max Mustermann", Telefon= "+49 1523 4567890", Email="mustermann@techsolutions.de", Nachricht="Guten Morgen! ☕", DeadLine =new DateTime(2025,04,12), Erledigt= false, Kommentar= "dringend" },
            new Anfrage{ KundenName= "Musterbau AG", ProjektName="BauMasterX", Ansprechpartner = "Julia Musterfrau", Telefon= "+49 176 9876543", Email="musterfrau@musterbau.de", Nachricht="Wie ist der Stand? 📊", DeadLine =new DateTime(2025,06,18), Erledigt= true, Kommentar= "alles geklärt" },
            new Anfrage{ KundenName= "Innovatech GmbH", ProjektName="TechFlow", Ansprechpartner = "Erika Richter", Telefon= "+49 160 2345678", Email="richter@innovatech.com", Nachricht="Bitte um Feedback! 🔄", DeadLine =new DateTime(2025,05,05), Erledigt= false, Kommentar= "prüfen" },
            new Anfrage{ KundenName= "GreenEnergy Solutions", ProjektName="SolarBoost", Ansprechpartner = "Wolfgang Bommes", Telefon= "+49 172 8765432", Email="bommes@greenenergy.com", Nachricht="Kann das umgesetzt werden? 🚀", DeadLine =new DateTime(2025,07,01), Erledigt= false, Kommentar= "Rücksprache nötig" },
            new Anfrage{ KundenName= "FutureWeb AG", ProjektName="WebNextGen", Ansprechpartner = "Anna Schmidt", Telefon= "+49 1512 3456789", Email="anna.schmidt@futureweb.de", Nachricht="Freue mich drauf! 🎉", DeadLine =new DateTime(2025,06,10), Erledigt= false, Kommentar= "wichtig" },
            new Anfrage{ KundenName= "LogiTrans GmbH", ProjektName="CargoFlex", Ansprechpartner = "Markus Weber", Telefon= "+49 170 9871234", Email="markus.weber@logitrans.com", Nachricht="Alles klar! 👍", DeadLine =new DateTime(2025,07,05), Erledigt= true, Kommentar= "schon erledigt" },
            new Anfrage{ KundenName= "MediCare Solutions", ProjektName="MediTrack", Ansprechpartner = "Sophia Klein", Telefon= "+49 160 7654321", Email="sophia.klein@medicare.com", Nachricht="Ruf mich an! 📞", DeadLine =new DateTime(2025,03,15), Erledigt= false, Kommentar= "sehr dringend" },
            new Anfrage{ KundenName= "SmartHome Systems", ProjektName="HomeGuardian", Ansprechpartner = "Leon Fischer", Telefon= "+49 1520 4567890", Email="leon.fischer@smarthome.de", Nachricht="Lass uns das besprechen. 🤔", DeadLine =new DateTime(2025,09,01), Erledigt= false, Kommentar= "noch Zeit" },
            new Anfrage{ KundenName= "FoodTech GmbH", ProjektName="FreshTrack", Ansprechpartner = "Mia Hoffmann", Telefon= "+49 176 5432109", Email="mia.hoffmann@foodtech.com", Nachricht="Das klingt super! 😃", DeadLine =new DateTime(2025,08,20), Erledigt= true, Kommentar= "positiv" },
            new Anfrage{ KundenName= "AutoVision AG", ProjektName="DriveSync", Ansprechpartner = "Tom Berger", Telefon= "+49 170 3210987", Email="tom.berger@autovision.de", Nachricht="Melde mich später. ⏳", DeadLine =new DateTime(2025,05,30), Erledigt= false, Kommentar= "nicht vergessen" }
        };


        // Daten abspeichern also die Datenbank mehr oder weniger darauf vorbereiten diese Daten abzuspeicher.
        context.AnfrageDaten.AddRange(anfragen);

        // Dieser Befehl speichert letztendlich die Daten auch in der Datenbank. 
        // Dieser Befehil MUSS am ausgeführt werden. 
        context.SaveChanges();
    }
}
