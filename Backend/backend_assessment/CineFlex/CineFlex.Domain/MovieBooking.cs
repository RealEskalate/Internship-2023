using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class MovieBooking : BaseDomainEntity
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    public int CinemaId { get; set; }
    public CinemaEntity Cinema { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    public List<Seat> Seats { get; set; } = new List<Seat>();
}