using System;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly CineFlexDbContex _dbContext;


        public SeatRepository(CineFlexDbContex context) : base(context)
        {
            _dbContext = context;
        }
        
    }
}