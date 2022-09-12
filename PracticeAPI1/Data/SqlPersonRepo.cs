using PracticeAPI1.Models;
using PracticeAPI1.Services;

namespace PracticeAPI1.Data
{
    public class SqlPersonRepo : IPersonRepo
    {
        private readonly AppDbContext _context;

        public SqlPersonRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
