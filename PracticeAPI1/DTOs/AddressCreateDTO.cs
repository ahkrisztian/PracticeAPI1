namespace PracticeAPI1.DTOs
{
    public class AddressCreateDTO
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int PersonId { get; set; }
    }
}
