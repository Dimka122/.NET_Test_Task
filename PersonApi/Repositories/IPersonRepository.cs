using PersonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersons();
        Task<IEnumerable<Person>> GetFilteredPersons(string firstName, string lastName, string city);
        Task<Person> GetPersonById(long id);
        Task<Person> AddPerson(Person person);
        Task<bool> UpdatePerson(Person person);
        Task<bool> DeletePerson(long id);
    }
}