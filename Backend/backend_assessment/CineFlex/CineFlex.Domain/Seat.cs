using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Seat: BaseDomainEntity
{
    public Movie Movie { get; set; }
    public CinemaEntity Cinema { get; set; }
    public string Location { get; set; }
    public bool Taken { get; set; } = false;
}