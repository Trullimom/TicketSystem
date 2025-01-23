using System.Diagnostics.Eventing.Reader;

namespace TicketSystem.Models
{
    public class MitarbeiterDaten
    {
        public static int countId = 0;
        public int  Id { get; set; }

        public string Rolle { get; set; }

        public string  UserName { get; set; }

        public int Passwort { get; set; }

        public static string Tester { get; set; }

        public static string Mitarbeiter { get; set; }

        public static string Admin { get; set; }


        public MitarbeiterDaten()
        {
            Id = countId;
            countId++;

            if (Rolle==Tester)
            {
                Console.WriteLine("hier ist der Tester");
            }
            else if(Rolle== Admin)
            {
                Console.WriteLine("hier ist der Admin ");
            }else
            {
                Console.WriteLine("Hier ist ein Mitarbeiter");
            }


        }
    }
}
