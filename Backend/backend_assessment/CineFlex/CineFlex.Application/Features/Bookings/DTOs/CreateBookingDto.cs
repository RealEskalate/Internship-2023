using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain.Common;
namespace CineFlex.Application.Features.Bookings.DTO;
public class CreateBookingDTO
{
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int UserId { get; set; }
    public string Seats { get; set; }
     public int row {get;set;}
    public int col {get;set;}
    public TimeSlot TimeSlot { get; set; }
}
