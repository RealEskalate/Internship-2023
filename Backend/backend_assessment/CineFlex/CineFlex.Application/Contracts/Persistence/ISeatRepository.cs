using CineFlex.Domain;

namespace CineFlex.Application.Contracts.Persistence;

public interface ISeatRepository: IGenericRepository<Seat>
{
    Task<List<Seat>> GetAll(int movie, int cinema);
}