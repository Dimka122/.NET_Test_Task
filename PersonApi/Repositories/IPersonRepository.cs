using PersonApi.Models;

namespace PersonApi.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person person);
        Task<IEnumerable<Person>> GetFilteredPersons(string firstName, string lastName, string city);
    }
}
