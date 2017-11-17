using Microsoft.EntityFrameworkCore;

namespace Stypendium.Models
{
    public class DataAccess : DbContext
    {
        public DataAccess(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Person> Persons { set; get; }
        public DbSet<Kierunek> Informatyka { set; get; }
        public DbSet<Przedmiot> Przedmioty { set; get; }
        
    }
}