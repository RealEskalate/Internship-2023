using CineFlex.Domain;

namespace CineFlex.Application.Features.Movies.DTOs
{
    public class BookConfirmationDto
    {
        public string BookingStatus { get; set; }
        public int BookingId { get; set; }
        public string MovieTitle { get; set; }
        public string CinemaName { get; set; }
        public List<Seat> BookedSeats { get; set; }
        // Additional properties as per your requirements
    }
}
