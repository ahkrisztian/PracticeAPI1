using Microsoft.EntityFrameworkCore;
using PracticeAPI1.Models;

namespace PracticeAPI1.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Address { get; set; }

        public AppDbContext() : base()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
