using CineFlex.Domain;

namespace CineFlex.Application.Contracts.Persistence;

public interface ISeatRepository : IGenericRepository<Seat>
{
    Task<IReadOnlyList<Seat>> GetByCinemaId(int requestCinemaId);

    Task<IReadOnlyList<Seat>> GetSeatsWithId(IList<int> seatIds);
}