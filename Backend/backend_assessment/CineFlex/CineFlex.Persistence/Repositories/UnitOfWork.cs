using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CineFlex.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineFlexDbContex _context;
        private IMovieRepository _MovieRepository;

        private ICinemaRepository _cinemaRepository;
        private ISeatRepository _seatRepository;
        private IBookingRepository _bookingRepository;
        private IServiceProvider _services;
        private UserManager<AppUser> _userManager;
        public UnitOfWork(CineFlexDbContex context,IServiceProvider services)
        {
            _context = context;
            _services = services;
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

        public ISeatRepository SeatRepository
        {
            get
            {
                if (_seatRepository == null)
                    _seatRepository = new SeatRepository(_context);
                return _seatRepository;
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

        public IBookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                    _bookingRepository = new BookingRepository(_context);
                return _bookingRepository;
            }
        }

        public UserManager<AppUser> UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = _services.GetService<UserManager<AppUser>>();

                return _userManager;
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
