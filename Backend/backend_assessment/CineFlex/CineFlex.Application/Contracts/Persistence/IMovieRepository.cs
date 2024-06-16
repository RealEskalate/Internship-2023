using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
    Task<List<Movie>> SearchMoviesAsync(string title);
    Task<List<Movie>> FilterMoviesByGenre(string genre);

    }
}
