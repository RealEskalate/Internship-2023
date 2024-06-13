using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CineFlexDbContex _context;
        public MovieRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Booking> BookMovie(BookMovieDto movieDto)
        {
            var movie = await _context.Movies.FindAsync(movieDto.MovieId);
            var cinema = await _context.Cinemas.FindAsync(movieDto.CinemaId);

            if (movie == null || cinema == null)
            {
                throw new Exception("Movie or cinema not found");
            }
            var booking = new Booking
            {
                MovieId = movie.Id,
                CinemaId = cinema.Id,
                Seats = movieDto.Seats
            };


            // Save the booking to the database
            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
