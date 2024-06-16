using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class SeatRepository : GenericRepository<SeatEntity>, ISeatRepository
    {

        private readonly CineFlexDbContex _dbContext;

        public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<SeatEntity> GetSeatByNumberAsync(int seatNumber, int cinemaId)
        {
            return await _dbContext.Seats.FirstOrDefaultAsync(s => s.SeatNumber == seatNumber && s.CinemaId == cinemaId);
        }


        public async Task<bool> IsSeatTakenAsync(int seatNumber, int cinemaId)
        {
            return await _dbContext.Seats.AnyAsync(s => s.SeatNumber == seatNumber && s.CinemaId == cinemaId);
        }

    }
}