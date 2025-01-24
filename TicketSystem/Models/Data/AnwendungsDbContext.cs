using TicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Models.Data
{
    public class AnwendungsDbContext : DbContext
    {
        public DbSet<Anfrage> AnfrageDaten { get; set; } // Füge hier weitere DbSet-Properties für andere Model-Klassen hinzu, falls benötigt
        public AnwendungsDbContext(DbContextOptions<AnwendungsDbContext> options) : base(options)
        {
            
        }

    }

}


