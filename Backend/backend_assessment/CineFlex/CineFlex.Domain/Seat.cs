using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class Seat:BaseDomainEntity
    {
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public DateTime lastBooked { get; set; }
        public CinemaEntity Cinema { get; set; }

        // Navigational Property
        public ICollection<BookingEntity> Bookings { get; set; }
        

     
    }
}
