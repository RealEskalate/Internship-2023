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
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
        public string ReleaseYear { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
