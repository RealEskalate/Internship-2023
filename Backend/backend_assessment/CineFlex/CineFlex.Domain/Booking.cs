using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CineFlex.Domain;


// Booking entity
public class Booking : BaseDomainEntity
{
    
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int UserId { get; set; }
    public int row { get; set; }
    public int col {get;set;}
    public TimeSlot TimeSlot { get; set; }
    // Additional booking-related properties can be added as needed
}
