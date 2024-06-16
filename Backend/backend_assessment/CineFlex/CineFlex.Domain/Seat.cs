using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Seat : BaseDomainEntity
{
    public int SeatNumber { get; set; }
    public bool IsBooked { get; set; }
    public int MovieBookingId {get; set;}
    public MovieBooking MovieBooking { get; set; } 


}
