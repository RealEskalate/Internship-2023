namespace CineFlex.Domain;

public class Seat : BaseDomainEntity
{
    public string SeatNumber { get; set; }
    public bool isHold { get; set; } = false;
    public int CinemaId { get; set; }
    public CinemaEntity Cinema { get; set; }
}
