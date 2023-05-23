using CineFlex.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IMovieBookingRepository : IGenericRepository<MovieBooking>
    {
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserId(string userId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByMovieId(int movieId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByCinemaId(int cinemaId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsBySeatId(int seatId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserIdAndMovieId(string userId, int movieId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserIdAndCinemaId(string userId, int cinemaId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserIdAndSeatId(string userId, int seatId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByMovieIdAndCinemaId(int movieId, int cinemaId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByMovieIdAndSeatId(int movieId, int seatId);
        Task<IEnumerable<MovieBooking>> GetMovieBookingsByCinemaIdAndSeatId(int cinemaId, int seatId);
    }
}
