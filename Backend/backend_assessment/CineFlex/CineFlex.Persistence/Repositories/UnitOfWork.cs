using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain.Models;
using CineFlex.Persistence;
using CineFlex.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private IUserRepository _UserRepository;
        private IMovieRepository _MovieRepository;
        private ICinemaRepository _CinemaRepository;
        private ISeatRepository _SeatRepository;
        private ITicketRepository _TicketRepository;

        public UnitOfWork(CineFlexDbContex context)
        {
            _context = context;
        }
        public UnitOfWork(CineFlexDbContex context, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
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
                if (_CinemaRepository == null)
                    _CinemaRepository = new CinemaRepository(_context);
                return _CinemaRepository;
            }
        }
        public ISeatRepository SeatRepository
        {
            get
            {
                if (_SeatRepository == null)
                    _SeatRepository = new SeatRepository(_context);
                return _SeatRepository;
            }
        }
        public ITicketRepository TicketRepository
        {
            get
            {
                if (_TicketRepository == null)
                    _TicketRepository = new TicketRepository(_context);
                return _TicketRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_UserRepository == null)
                    _UserRepository = new UserRepository(_userManager, _configuration, _context);
                return _UserRepository;
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
