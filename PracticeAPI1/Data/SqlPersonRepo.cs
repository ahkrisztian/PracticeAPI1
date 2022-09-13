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
            if(person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }


        public IEnumerable<Person> GetAllPersons()
        {
            addAddresses();

            return _context.Persons.ToList();
        }


        public Person GetPersonById(int id)
        {
            addAdressesById(id);

            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePerson()
        {
            _context.SaveChanges();
        }

        public void addAddresses()
        {
            _context.Address.ToList();
        }

        public void addAdressesById(int id)
        {
            _context.Address.ToList().Where(x => x.Id == id);
        }
    }
}
