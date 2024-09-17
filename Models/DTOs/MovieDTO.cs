using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
    }
}
