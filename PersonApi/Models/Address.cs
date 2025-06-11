using System;

namespace PersonApi.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
