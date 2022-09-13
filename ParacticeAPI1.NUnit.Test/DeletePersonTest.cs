using Microsoft.EntityFrameworkCore;
using PracticeAPI1.Models;
using PracticeAPI1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParacticeAPI1.NUnit.Test
{
    public class DeletePersonTest
    {
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=PracticeAPI1; Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options);

            var person = new Person()
            {
                FirstName = "Paul",
                LastName = "Benet",
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        AddressLine = "Kensigton Str. 1",
                        City = "Baltimore",
                        ZipCode = "23487",
                        Country = "USA"
                    },
                    new Address()
                    {
                        AddressLine = "Jamaica Str. 11",
                        City = "Baltimore",
                        ZipCode = "23456",
                        Country = "USA"
                    }
                }
            };

            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        [Test]
        public void DeletePerson()
        {
            var person = _context.Persons.Single(p => p.FirstName == "Paul" && p.LastName == "Benet");

            var personId = person.Id;

            _context.Persons.Remove(person);
            _context.SaveChanges();

            var found = _context.Persons.SingleOrDefault(p => p.FirstName == "Paul" && p.LastName == "Benet");
            Assert.IsNull(found);

            var address = _context.Address.Where(x => x.PersonId == personId);
            Assert.AreEqual(0, address.Count());
        }
    }
}
