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
        public SeatLevel Level { get; set; }
    }
}
