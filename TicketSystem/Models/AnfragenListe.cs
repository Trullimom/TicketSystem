namespace TicketSystem.Models
{
    public class AnfragenListe
    {
        public static List<Anfrage> anfragenListe { get; set; } = new List<Anfrage>()
        {
            new Anfrage{ KundenName= "Kunde1", MitarbeiterName = "Andre", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "blablabla" },
            new Anfrage{ KundenName= "Kunde2", MitarbeiterName = "Jihye", DeadLine =new DateTime(2025,01,23), Erledigt= true, Kommentar= "blablabla" },
            new Anfrage{ KundenName= "Kunde3", MitarbeiterName = "Marcel", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "blablabla" },
            new Anfrage{ KundenName= "Kunde4", MitarbeiterName = "Abdullah", DeadLine =new DateTime(2025,01,23), Erledigt= false, Kommentar= "blablabla" },


        };




    }
}
