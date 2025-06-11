using AutoMapper;
using PersonApi.DTOs;
using PersonApi.Models;
using PersonApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PersonApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPersons()
        {
            var persons = await _personRepository.GetAllPersons();
            return _mapper.Map<IEnumerable<PersonDTO>>(persons);
        }

        public async Task<IEnumerable<PersonDTO>> GetFilteredPersons(GetAllRequest request)
        {
            var persons = await _personRepository.GetFilteredPersons(
                request.FirstName,
                request.LastName,
                request.City);

            return _mapper.Map<IEnumerable<PersonDTO>>(persons);
        }

        public async Task<PersonDTO> GetPersonById(long id)
        {
            var person = await _personRepository.GetPersonById(id);
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<PersonDTO> CreatePerson(CreatePersonDTO createPersonDto)
        {
            var person = _mapper.Map<Person>(createPersonDto);
            var createdPerson = await _personRepository.AddPerson(person);
            return _mapper.Map<PersonDTO>(createdPerson);
        }

        public async Task<bool> UpdatePerson(UpdatePersonDTO updatePersonDto)
        {
            var person = _mapper.Map<Person>(updatePersonDto);
            return await _personRepository.UpdatePerson(person);
        }

        public async Task<bool> DeletePerson(long id)
        {
            return await _personRepository.DeletePerson(id);
        }
    }
}