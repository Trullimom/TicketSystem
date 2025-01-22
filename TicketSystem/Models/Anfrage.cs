namespace TicketSystem.Models
{
    public class Anfrage
    {

        private static int countId = 0;  
        public int Id { get; set; }

        public string KundenName { get; set; }

        public DateTime Datum { get; set; }

        public bool Erledigt { get; set; }

        public DateTime DeadLine { get; set; }

        public string Kommentar { get; set; }
        public int Priorität { get; set; }

        public Anfrage()  // das ist der Konstruktor 
        {
            Id = countId;  // beim ersten mal fängt mit 0 an //
            countId++;   // bei zweiten mal wird eins erhöht
        }
    }
}
