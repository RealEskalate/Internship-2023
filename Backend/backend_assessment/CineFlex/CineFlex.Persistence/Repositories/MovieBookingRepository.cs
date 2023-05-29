using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class MovieBookingRepository : GenericRepository<MovieBooking>, IMovieBookingRepository
    {
        private readonly CineFlexDbContex _context;
        public MovieBookingRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
