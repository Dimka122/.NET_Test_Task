using System;

namespace PersonApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
