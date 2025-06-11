namespace PersonApi.DTOs
{
    public class UpdatePersonDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? AddressId { get; set; }
    }
}
