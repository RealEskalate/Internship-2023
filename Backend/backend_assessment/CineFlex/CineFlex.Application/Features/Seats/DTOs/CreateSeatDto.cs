using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Seats.DTOs;

public class CreateSeatDto : BaseDto,ISeatDto
{
    public int SeatNumber { get; set; }

}
