using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Seat : BaseDomainEntity
{
    public int CinemaId { get; set; }
    public CinemaEntity Cinema { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<MovieBooking> MovieBookings { get; set; } = new List<MovieBooking>();
}