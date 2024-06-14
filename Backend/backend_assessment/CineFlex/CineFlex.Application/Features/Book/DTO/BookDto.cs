namespace CineFlex.Application.Features.Book.DTO
{
    public class BookDto : IBookDto
    {
        public int UserId { get; set; }

        public int MovieId { get; set; }
        public int SeatId { get; set; }
        public int CinemaId { get; set; }


    }
}