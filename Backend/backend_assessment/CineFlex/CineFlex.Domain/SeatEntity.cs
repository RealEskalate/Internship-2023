using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class SeatEntity : BaseDomainEntity
    {
        public int SeatNumber { get; set; }
        public int CinemaId { get; set; }
        public CinemaEntity Cinema { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public bool IsTaken { get; set;} = false;

    }
}