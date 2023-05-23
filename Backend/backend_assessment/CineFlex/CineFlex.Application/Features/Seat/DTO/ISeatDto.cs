namespace CineFlex.Application.Features.Seat.DTO
{
    public interface ISeatDto
    {

        public string SeatType { get; set; }




        public bool Available { get; set; }


        public decimal Price { get; set; }

    }
}