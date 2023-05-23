using CineFlex.Domain.Common;
namespace CineFlex.Domain;

public enum SeatType{
    VIP, Regular, WheelChair
}
public enum Availability{
    Taken,
     Free
}
public class Seat : BaseDomainEntity
{
    public string SeatNumber { get; set; }
    public SeatType SeatType { get; set; }
    public Availability Availability { get; set; }

    // Foreign key referencing the associated cinema
    public int CinemaID { get; set; }
    public CinemaEntity Cinema { get; set; }

    // Foreign key referencing the associated movie
    public int MovieID { get; set; }
    public Movie Movie { get; set; }
}