using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Cinema.DTO
{
    public class CreateCinemaDto : ICinemaDto
    {
        public string Name { get ; set ; }
        public string Location { get; set ; }
        public string ContactInformation { get; set; }
        public ICollection<SeatProfile> Seats { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
