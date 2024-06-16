using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class Movie: BaseDomainEntity
    {
        public Movie()
            {
                
            }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public List<MovieBooking> MovieBookings { get; set; } // Relationship with MovieBooking


    }
}
