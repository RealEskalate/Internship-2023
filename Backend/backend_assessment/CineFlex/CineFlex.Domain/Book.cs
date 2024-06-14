using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Book : BaseDomainEntity
    {

        public int MovieId { get; set; }
        public int SeatId { get; set; }
        public int CinemaId { get; set; }
        public int UserId { get; set; }
    }
}