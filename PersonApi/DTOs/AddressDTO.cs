namespace PersonApi.Models
{
   
        public class AddressDTO
        {
            public int Id { get; set; }
            public string City { get; set; }
            public string AddressLine { get; set; }
        }

        public class CreateAddressDTO
        {
            public string City { get; set; }
            public string AddressLine { get; set; }
        }
}
