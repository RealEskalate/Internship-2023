
using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
	public class Seat : BaseDomainEntity
	{
		public int SeatNumber { get; set; }
		public string SeatType { get; set; } // regular, VIP, recliner.
		public bool isAvailable { get; set; } //available, not_available.
		public int CinemaId { get; set; } 
	}
	
}
