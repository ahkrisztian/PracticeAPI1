using AutoMapper;
using PracticeAPI1.DTOs;
using PracticeAPI1.Models;

namespace PracticeAPI1.Profiles
{
    public class PeopleProfiles: Profile
    {
        public PeopleProfiles()
        {
            CreateMap<Person, PersonReadDTO>();
            CreateMap<PersonCreateDTO, Person>();
            CreateMap<Address, AddressReadDTO>();
            CreateMap<AddressCreateDTO, Address>();
            CreateMap<Person, PersonUpdateDTO>();
            CreateMap<PersonUpdateDTO, Person>();
        }
    }
}
