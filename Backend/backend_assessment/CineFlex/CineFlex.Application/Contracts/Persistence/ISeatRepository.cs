using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface ISeatRepository : IGenericRepository<SeatEntity>
    {
        Task<bool> IsSeatTakenAsync(int seatNumber, int cinemaId);

        Task<SeatEntity> GetSeatByNumberAsync(int seatNumber, int cinemaId);


    }
}
