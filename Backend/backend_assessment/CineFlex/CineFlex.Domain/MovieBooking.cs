using CineFlex.Domain.Common;
using System.Collections.Generic;

namespace CineFlex.Domain
{
    public class MovieBooking : BaseDomainEntity
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public List<Seats> Seats { get; set; }
    }
}
