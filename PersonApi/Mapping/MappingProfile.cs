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
            // Person mappings
            CreateMap<Person, PersonDTO>();
            CreateMap<CreatePersonDTO, Person>();

            // Address mappings
            CreateMap<Address, DTOs.AddressDTO>();
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<CreateAddressDTO, Address>().ReverseMap();
        }
    }
}