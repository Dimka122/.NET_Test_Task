using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.Models;

namespace PersonApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> GetFilteredPersons(string firstName, string lastName, string city)
        {
            var query = _context.Persons.Include(p => p.Address).AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(p => p.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(p => p.LastName.Contains(lastName));

            if (!string.IsNullOrEmpty(city))
                query = query.Where(p => p.Address != null && p.Address.City.Contains(city));

            return await query.ToListAsync();
        }
    }
}
