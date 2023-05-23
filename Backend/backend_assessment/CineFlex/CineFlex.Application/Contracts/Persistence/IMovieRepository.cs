using CineFlex.Domain;

namespace CineFlex.Application.Contracts.Persistence;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<IReadOnlyList<Movie>> GetMoviesByTitle(string query);
}