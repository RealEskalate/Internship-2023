using CineFlex.Application.Contracts.Persistence;
using CineFlex.Persistence;
using CineFlex.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineFlexDbContex _context;
        private IMovieRepository _MovieRepository;
        private IMovieBookingRepository _movieBookingRepository;
        private ICinemaRepository _cinemaRepository;

        private ISeatRepository _seatRepository;

        public UnitOfWork(CineFlexDbContex context)
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
        public IMovieBookingRepository MovieBookingRepository
        {
            get
            {
                if (_movieBookingRepository == null)
                    _movieBookingRepository = new MovieBookingRepository(_context);
                return _movieBookingRepository;
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
