using System;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly CineFlexDbContex _dbContext;
        
        public BookingRepository(CineFlexDbContex context) : base(context)
        {
            _dbContext = context;
        }
        
    }
}