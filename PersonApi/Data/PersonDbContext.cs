using Microsoft.EntityFrameworkCore;
using PersonApi.Models;

namespace PersonApi.Data
{
    public class PersonDbContext: DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithMany(a => a.Persons)
                .HasForeignKey(p => p.AddressId);
        }
    }
}
