using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface ISeatRepository : IGenericRepository<Seats>
    {
        Task<IEnumerable<Seats>> GetSeatsByCinemaIdAsync(int cinemaId);
    }
}
