using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Book.DTO
{
    public class UpdateBookDto : BaseDto, IBookDto
    {

        public int MovieId { get; set; }
        public int SeatId { get; set; }
        public int CinemaId { get; set; }

    }
}