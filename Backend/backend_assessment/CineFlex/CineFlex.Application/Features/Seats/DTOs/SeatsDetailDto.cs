using  CineFlex.Application.Features.Seats.DTOs;

namespace CineFlex.Application.Features.Seats.DTOs;

public class SeatsDetailDto
{

    public int CinemaId { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }
    public string SeatType { get; set; }
    public decimal Price { get; set; }
}