
using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs
{
    public class CreateTicketDto: BaseDto
    {
        public int SeatID { get; set; }
        public string UserID { get; set; }   
    }
}