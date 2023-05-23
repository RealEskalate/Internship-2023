using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence.Repositories
{
    public class CinemaRepository : GenericRepository<CinemaEntity>, ICinemaRepository
    {
        private readonly CineFlexDbContex _context;
        private readonly IMapper _mapper;

        public CinemaRepository(CineFlexDbContex dbContext, IMapper mapper) : base(dbContext)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<CinemaDto> AddCinemaAsync(CreateCinemaDto cinemaDto)
        {
            var cinemaEntity = _mapper.Map<CinemaEntity>(cinemaDto);

            await Add(cinemaEntity);

            var createdCinemaDto = _mapper.Map<CinemaDto>(cinemaEntity);
            return createdCinemaDto;
        }

        public async Task<IEnumerable<CinemaDto>> GetAllCinemasAsync()
        {
            var cinemas = await GetAll();

            var cinemaDtos = _mapper.Map<IEnumerable<CinemaDto>>(cinemas);
            return cinemaDtos;
        }

        public async Task<CinemaDto> GetCinemaByIdAsync(int cinemaId)
        {
            var cinemaEntity = await Get(cinemaId);

            if (cinemaEntity == null)
                return null;

            var cinemaDto = _mapper.Map<CinemaDto>(cinemaEntity);
            return cinemaDto;
        }

        public async Task<IEnumerable<CinemaEntity>> GetCinemasByContactInformationAsync(string contactInformation)
        {
            return await _context.Cinemas.Where(cinema => cinema.ContactInformation == contactInformation).ToListAsync();
        }

        public async Task<IEnumerable<CinemaEntity>> GetCinemasByLocationAsync(string location)
        {
            return await _context.Cinemas.Where(cinema => cinema.Location == location).ToListAsync();
        }

        public async Task<CinemaDto> UpdateCinemaAsync(UpdateCinemaDto cinemaDto)
        {
            var cinemaEntity = await Get(cinemaDto.Id);

            if (cinemaEntity == null)
                return null;

            cinemaEntity.Name = cinemaDto.Name;
            cinemaEntity.Location = cinemaDto.Location;
            cinemaEntity.ContactInformation = cinemaDto.ContactInformation;

            await Update(cinemaEntity);

            var updatedCinemaDto = _mapper.Map<CinemaDto>(cinemaEntity);
            return updatedCinemaDto;
        }
    }
}
