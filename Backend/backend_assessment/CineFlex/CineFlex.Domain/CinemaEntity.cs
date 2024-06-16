using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class CinemaEntity:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
        public List<MovieBooking> MovieBookings { get; set; } // Relationship with MovieBooking

    }
}
