using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
