using CineFlex.Domain;
using CineFlex.Application.Features.Cinema.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CineFlex.Application.Features.Cinema.Dtos;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface ICinemaRepository : IGenericRepository<CinemaEntity>
    {
        Task<IEnumerable<CinemaEntity>> GetCinemasByLocationAsync(string location);
        Task<IEnumerable<CinemaEntity>> GetCinemasByContactInformationAsync(string contactInformation);
        Task<IEnumerable<CinemaDto>> GetAllCinemasAsync();
        Task<CinemaDto> GetCinemaByIdAsync(int cinemaId);
        Task<CinemaDto> AddCinemaAsync(CreateCinemaDto cinemaDto);
        Task<CinemaDto> UpdateCinemaAsync(UpdateCinemaDto cinemaDto);
    }
}
