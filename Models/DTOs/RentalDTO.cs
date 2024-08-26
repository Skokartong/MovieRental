namespace MovieRental.Models.DTOs
{
    public class RentalDTO
    {
        public int FK_UserId { get; set; }
        public int FK_MovieId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
