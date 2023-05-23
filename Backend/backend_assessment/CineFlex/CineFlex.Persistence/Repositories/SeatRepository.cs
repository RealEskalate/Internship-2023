using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using CineFlex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class SeatRepository : GenericRepository<Seats>, ISeatRepository
    {
        private readonly CineFlexDbContex _context;
        private readonly IMapper _mapper;

        public SeatRepository(CineFlexDbContex dbContext, IMapper mapper) : base(dbContext)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Seats>> GetSeatsByCinemaIdAsync(int cinemaId)
        {
            return await _context.Seats.Where(s => s.CinemaId == cinemaId).ToListAsync();
        }
    }
}
