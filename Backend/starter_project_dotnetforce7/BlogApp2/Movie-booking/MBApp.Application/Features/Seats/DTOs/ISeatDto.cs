
namespace MBApp.Application.Features.Seats.DTOs
{
	public interface ISeatDto
	{
		public string SeatNumber { get; set; }
		public string SeatType { get; set; } // regular, VIP, recliner.
		public bool isAvailable { get; set; } //available, not_available.
		public Cinema Cinema { get; set; } 
	}
}