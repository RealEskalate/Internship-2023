using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Seat: BaseDomainEntity
    {
        public int CinemaId {get; set;}

        public string SeatLocation { get; set; }

        public bool Available {get; set;}

        public CinemaEntity Cinema {get; set;}

    }
}
