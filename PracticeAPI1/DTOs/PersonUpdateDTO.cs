using PracticeAPI1.Models;
using System.ComponentModel.DataAnnotations;

namespace PracticeAPI1.DTOs
{
    public class PersonUpdateDTO
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
