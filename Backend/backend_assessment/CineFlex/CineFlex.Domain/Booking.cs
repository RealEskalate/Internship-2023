using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Booking: BaseDomainEntity
{
    // public User User { get; set; }
    public Seat Seat { get; set; }
}