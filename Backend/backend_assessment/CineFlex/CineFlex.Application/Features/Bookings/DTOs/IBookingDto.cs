using CineFlex.Domain;

namespace CineFlex.Application.Features.Bookings.DTOs
{
    public interface IBookingDto
    {
        public int CinemaId { get; set; }
        public ICollection<int> SeatsId { get; set; }
        public int MovieId { get; set; }
    }
}