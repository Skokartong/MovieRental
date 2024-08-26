using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int FK_MovieId { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("User")]
        public int FK_UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
