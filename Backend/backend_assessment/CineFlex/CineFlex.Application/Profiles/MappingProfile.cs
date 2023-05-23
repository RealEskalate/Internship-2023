using AutoMapper;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Seats.DTOs;

using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Movie Mappings

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();

            CreateMap<Movie, UpdateMovieDto>().ReverseMap();

            #endregion Movie
            CreateMap<CinemaEntity, CreateCinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, CinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, UpdateCinemaDto>().ReverseMap();


            #region Seats Mappings
            CreateMap<Seat, SeatsDto>().ReverseMap();
            CreateMap<Seat, CreateSeatsDto>().ReverseMap();
            CreateMap<Seat, SeatsDetailDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatsDto>().ReverseMap();
            CreateMap<Seat, SeatsListDto>().ReverseMap();
            #endregion Seats
        }
    }
}
