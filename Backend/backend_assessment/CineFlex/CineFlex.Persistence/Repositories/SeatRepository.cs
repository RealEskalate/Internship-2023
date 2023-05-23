using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using CineFlex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence;

public class SeatRepository: GenericRepository<Seat>, ISeatRepository
{
    private readonly CineFlexDbContex _context;
    public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<Seat> Get(int id)
    {
        var withMovies = _context.Seats.Include(b => b.Movie);
        var withCinemas = withMovies.Include(b => b.Cinema);
        
        return await withCinemas.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Seat>> GetAll(int movie, int cinema)
    {
        var withMovies = _context.Seats.Include(b => b.Movie);
        var withCinemas = withMovies.Include(b => b.Cinema);

        return await withCinemas.Where(b => b.Cinema.Id == cinema && b.Movie.Id == movie).ToListAsync();
    }
}