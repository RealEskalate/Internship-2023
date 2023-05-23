
using CineFlex.Domain;
using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Booking
{
    
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int UserId { get; set; }
    public DateTime BookingTime { get; set; }
    public List<Seat> Seats { get; set; }
    
    // Additional properties, if needed
    
    // Navigation properties, if needed
}
