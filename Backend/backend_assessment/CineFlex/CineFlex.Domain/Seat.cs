using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Seat : BaseDomainEntity
    {
        public int SeatNo { get; set; }
        public CinemaEntity  Cinema { get; set; } 
        public bool Free { get; set; }
    }
}