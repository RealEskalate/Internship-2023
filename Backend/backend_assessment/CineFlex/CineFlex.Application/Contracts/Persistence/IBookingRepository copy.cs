using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Domain;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IBookingRepository:IGenericRepository<Booking>
    {

        public Task<Booking> GetBookingDetail(int Id);
        public Task<List<Booking>> GetAllWithDetail();
    }
}
