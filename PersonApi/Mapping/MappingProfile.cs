using AutoMapper;
using PersonApi.DTOs;
using PersonApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePersonDTO, Person>();
            CreateMap<Person, PersonDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }
}