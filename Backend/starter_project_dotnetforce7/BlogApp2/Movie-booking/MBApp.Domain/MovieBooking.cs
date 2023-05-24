using MBApp.Domain.Common;


namespace MBApp.Domain
{
	public class MovieBooking : BaseEntity
   {
	public User User { get; set; }
	public Movie Movie { get; set; }
	public Cinema Cinema { get; set; } 
	public List<Seat> SelectedSeats { get; set; }
   }
} 