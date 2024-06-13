using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public enum SeatStatus
    {
        Available,
        Booked,
        Occupied
    }

    public enum SeatType
    {
        Standard,
        VIP,
        Recliner,
        WheelchairAccessible
    }

    public class Seats
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public string cinemaEntity { get; set; }
        public int RowNumber { get; set; }
        public SeatType SeatType { get; set; }
        public SeatStatus SeatStatus { get; set; }
        public decimal SeatPrice { get; set; }
        public string SeatDescription { get; set; }
        public DateTime DateTime { get; set;}
    }
}
