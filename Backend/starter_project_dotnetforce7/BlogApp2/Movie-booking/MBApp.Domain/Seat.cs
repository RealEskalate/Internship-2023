
using MBApp.Domain.Common;

namespace MBApp.Domain
{
	public class Seat : BaseEntity
	{
		public string SeatNumber { get; set; }
		public string SeatType { get; set; } // regular, VIP, recliner.
		public bool isAvailable { get; set; } //available, not_available.
		public Cinema Cinema { get; set; } 
	}
	
}
