namespace PersonApi.DTOs
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
    }

    public class AddressDTO
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }

    public class CreatePersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? AddressId { get; set; }
    }

    
}