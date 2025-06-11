using PersonApi.DTOs;

namespace PersonApi.Services
{
    public interface IPersonService
    {
        Task<PersonDTO> CreatePerson(CreatePersonDTO createPersonDto);
        Task<IEnumerable<PersonDTO>> GetFilteredPersons(GetAllRequest request);
    }
}
