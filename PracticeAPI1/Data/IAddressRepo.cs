using PracticeAPI1.Models;

namespace PracticeAPI1.Data
{
    public interface IAddressRepo
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById(int id);
        void CreateAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(Address address);
    }
}
