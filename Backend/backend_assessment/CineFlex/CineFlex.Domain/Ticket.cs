

using CineFlex.Domain.Common;
using CineFlex.Domain.Models;

namespace CineFlex.Domain
{
    public class Ticket: BaseDomainEntity
    {
        public int SeatID { get; set; }
        public string UserID { get; set; }   

        public Seat Seat { get; set; }
        public AppUser User { get; set; }     
    }
}