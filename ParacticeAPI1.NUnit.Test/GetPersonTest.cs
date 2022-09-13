using Microsoft.EntityFrameworkCore;
using PracticeAPI1.Models;
using PracticeAPI1.Services;

namespace ParacticeAPI1.NUnit.Test
{
    public class Tests
    {
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=PracticeAPI1; Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options);
        }

        [Test]
        public void GetAllPersons()
        {
            //Get all Persons from Db and count

            IEnumerable<Person> persons = _context.Persons.ToList();

            Assert.AreEqual(3, persons.Count());
        }

        [Test]
        public void PersonHaveAddresses()
        {
            //Get one Person from Db and count their addresses

            List<Person> persons = _context.Persons.Include("Addresses").ToList();

            Assert.AreEqual(2, persons[0].Addresses.Count);
            Assert.AreEqual(1, persons[1].Addresses.Count);
        }
       
    }
}