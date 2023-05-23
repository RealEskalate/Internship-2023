using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class MovieBooking : BaseDomainEntity
{
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int UserId { get; set; }
    public List<int> SeatIds { get; set; } = null!;
}