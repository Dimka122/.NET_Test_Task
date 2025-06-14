using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.Include(p => p.Address).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetFilteredPersons(string? firstName, string? lastName, string? city)
        {
            var query = _context.Persons
                .Include(p => p.Address)
                .AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(p => p.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(p => p.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(p => p.Address != null && p.Address.City.Contains(city));
            }

            return await query.ToListAsync();
        }

        public async Task<Person> GetPersonById(long id)
        {
            return await _context.Persons
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> AddPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}