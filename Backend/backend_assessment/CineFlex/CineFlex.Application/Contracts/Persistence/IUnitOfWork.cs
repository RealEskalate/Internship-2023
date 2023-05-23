using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        ISeatRepository SeatRepository { get; }
        IBookingRepository BookingRepository {get; }
        UserManager<AppUser> UserManager { get;  }
        Task<int> Save();
        
    }
}
