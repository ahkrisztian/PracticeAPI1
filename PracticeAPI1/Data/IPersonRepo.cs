using PracticeAPI1.Models;

namespace PracticeAPI1.Data
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int id);
        void CreatePerson(Person person);
        void UpdatePerson();
        void DeletePerson(Person person);
    }
}
