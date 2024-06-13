
using CineFlex.Domain;

namespace CineFlex.Application.Features.Seats.DTOs
{
	public interface ISeatDto
	{
		public int SeatNumber { get; set; }
		public string SeatType { get; set; } // regular, VIP, recliner.
		public bool isAvailable { get; set; } //available, not_available.
		public int CinemaId { get; set; } 
	}
}