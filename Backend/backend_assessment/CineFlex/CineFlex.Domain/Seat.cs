using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Seats : BaseDomainEntity
    {
        public string Number { get; set; }
        public bool IsAvailable { get; set; }
        public int CinemaId { get; set; }
        public CinemaEntity Cinema { get; set; }
    }
}
