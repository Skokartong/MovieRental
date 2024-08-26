using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
