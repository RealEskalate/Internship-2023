using CineFlex.Application.Contracts.Persistence;
using CineFlex.Persistence;
using CineFlex.Persistence.Repositories;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineFlexDbContex _context;
        private readonly IMapper _mapper;

        private IMovieRepository _movieRepository;
        private ICinemaRepository _cinemaRepository;
        private ISeatRepository _seatRepository;

        public UnitOfWork(CineFlexDbContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (_movieRepository == null)
                    _movieRepository = new MovieRepository(_context, _mapper);
                return _movieRepository;
            }
        }

        public ICinemaRepository CinemaRepository
        {
            get
            {
                if (_cinemaRepository == null)
                    _cinemaRepository = new CinemaRepository(_context, _mapper);
                return _cinemaRepository;
            }
        }

        public ISeatRepository SeatRepository
        {
            get
            {
                if (_seatRepository == null)
                    _seatRepository = new SeatRepository(_context, _mapper);

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
