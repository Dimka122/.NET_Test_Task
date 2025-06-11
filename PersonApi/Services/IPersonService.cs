using PersonApi.DTOs;

namespace PersonApi.Services
{
    public interface IPersonService
    {
        Task<PersonDTO> CreatePerson(CreatePersonDTO createPersonDto);
        Task<IEnumerable<PersonDTO>> GetFilteredPersons(GetAllRequest request);
        Task<PersonDTO> GetPersonById(long id);
        Task<IEnumerable<PersonDTO>> GetAllPersons();
        Task<bool> UpdatePerson(UpdatePersonDTO updatePersonDto);
        Task<bool> DeletePerson(long id);
    }
}
