using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PracticeAPI1.Models;
using PracticeAPI1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParacticeAPI1.NUnit.Test
{
    [TestFixture]
    public class AddPersonTest
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
        public void InsertPersonWithAddressesToDb()
        {
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

            var addedPerson = _context.Persons.Single(p => p.FirstName == "Paul" && p.LastName == "Benet");

            Assert.Greater(addedPerson.Id, 0);

            Assert.AreEqual(addedPerson.Addresses.Count, 2);

            Assert.AreEqual(person.FirstName, addedPerson.FirstName);

            for (int i = 0; i < person.Addresses.Count; i++)
            {
                Assert.AreEqual(person.Addresses[i].City, addedPerson.Addresses[i].City);

                Assert.AreEqual(person.Addresses[i].Country, addedPerson.Addresses[i].Country);
            }



        }

        [TearDown]
        public void TearDown()
        {
            var person = _context.Persons.Single(p => p.FirstName == "Paul" && p.LastName == "Benet");

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
