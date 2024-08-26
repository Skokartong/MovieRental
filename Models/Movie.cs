using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
