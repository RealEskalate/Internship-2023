

using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Seat : BaseDomainEntity
    {
    public int SeatNumber {get; set;}    
    public bool IsBooked {get; set;} 
       
    public CinemaEntity? BelongsTo {get; set;}
    public string? UserId { get; set; }
    public User BookedBy {get; set;}


    }
}