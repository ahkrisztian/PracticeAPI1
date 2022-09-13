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
    public class UpdatePersonTest
    {
        private AppDbContext _context;

        private int personId;

        [SetUp]
        public void Setup()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=PracticeAPI1; Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options);

            var person = new Person()
            {
                FirstName = "Kemp",
                LastName = "Boris",
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        AddressLine = "Polker Str. 100",
                        City = "Cleveland",
                        ZipCode = "75487",
                        Country = "USA"
                    },
                    new Address()
                    {
                        AddressLine = "Bourbon Str. 166",
                        City = "Cleveland",
                        ZipCode = "75440",
                        Country = "USA"
                    }

                }
            };

            _context.Persons.Add(person);
            _context.SaveChanges();

            personId = person.Id;
        }

        [Test]
        public void UpdatePersonWithAddress()
        {
            var person = _context.Persons.Single(p => p.Id == personId);

            string firstName = "Jospeh";
            person.FirstName = firstName;

            string country = "Germany";

            var address = person.Addresses.First();
            address.Country = country;

            _context.SaveChanges();

            var updatedperson = _context.Persons.Single(p => p.Id == personId);

            Assert.AreEqual(firstName, updatedperson.FirstName);

            Assert.AreEqual(country, updatedperson.Addresses.First().Country);
        }

        [TearDown]

        public void TearDown()
        {
            var person = _context.Persons.Single(p => p.Id == personId);

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

    }
}
