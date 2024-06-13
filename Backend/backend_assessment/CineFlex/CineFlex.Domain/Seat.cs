using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public enum SeatLevel
    {
        Regular,
        VIP,
        VVIP
    }
    public class Seat : BaseDomainEntity
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsReserved { get; set; }
        public string SeatLevel { get; set; }
        public int CinemaId { get; set; }
        public CinemaEntity Cinema { get; set; }
    }
}
