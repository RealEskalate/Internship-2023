using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class MovieBookingRepository : GenericRepository<MovieBooking>, IMovieBookingRepository
    {
        private readonly CineFlexDbContex _dbContext;

        public MovieBookingRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserId(string userId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByMovieId(int movieId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.MovieId == movieId).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByCinemaId(int cinemaId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.CinemaId == cinemaId).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsBySeatId(int seatId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.Seats.Any(s => s.Id == seatId)).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserIdAndMovieId(string userId, int movieId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.UserId == userId && mb.MovieId == movieId).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserIdAndCinemaId(string userId, int cinemaId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.UserId == userId && mb.CinemaId == cinemaId).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByUserIdAndSeatId(string userId, int seatId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.UserId == userId && mb.Seats.Any(s => s.Id == seatId)).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByMovieIdAndCinemaId(int movieId, int cinemaId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.MovieId == movieId && mb.CinemaId == cinemaId).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByMovieIdAndSeatId(int movieId, int seatId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.MovieId == movieId && mb.Seats.Any(s => s.Id == seatId)).ToListAsync();
        }

        public async Task<IEnumerable<MovieBooking>> GetMovieBookingsByCinemaIdAndSeatId(int cinemaId, int seatId)
        {
            return await _dbContext.MovieBookings.Where(mb => mb.CinemaId == cinemaId && mb.Seats.Any(s => s.Id == seatId)).ToListAsync();
        }
    }
}
