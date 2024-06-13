using CineFlex.Domain;
using CineFlex.Domain.Common;


namespace CineFlex.Domain
{
	public class MovieBooking : BaseDomainEntity
   {
	// public User User { get; set; }
	public Movie Movie { get; set; }
	public CinemaEntity Cinema { get; set; } 
	public List<Seat> SelectedSeats { get; set; }
   }
} 