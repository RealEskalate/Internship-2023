using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain;
public class Booking: BaseDomainEntity
{
    public int BookingId { get; set; }
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int UserId { get; set; }
    public List<string> Seats { get; set; }
}
