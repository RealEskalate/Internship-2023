using CineFlex.Application.Contracts.Persistence;

namespace CineFlex.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineFlexDbContext _context;
        private IMovieRepository? _MovieRepository;

        private ICinemaRepository? _cinemaRepository;
        private ISeatRepository? _seatRepository;
        private IMovieBookingRepository? _movieBookingRepository;


        public UnitOfWork(CineFlexDbContext context)
        {
            _context = context;
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (_MovieRepository == null)
                    _MovieRepository = new MovieRepository(_context);
                return _MovieRepository;
            }
        }

        public ICinemaRepository CinemaRepository
        {
            get
            {
                if (_cinemaRepository == null)
                    _cinemaRepository = new CinemaRepository(_context);
                return _cinemaRepository;
            }
        }

        public ISeatRepository SeatRepository
        {
            get
            {
                if (_seatRepository == null)
                    _seatRepository = new SeatRepository(_context);
                return _seatRepository;
            }
        }

        public IMovieBookingRepository MovieBookingRepository
        {
            get
            {
                if (_movieBookingRepository == null)
                    _movieBookingRepository = new MovieBookingRepository(_context);

                return _movieBookingRepository;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}