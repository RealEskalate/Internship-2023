using AutoMapper;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seats.DTOs;

namespace CineFlex.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Movie Mappings

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();
            CreateMap<Movie, BookMovieDto>().ReverseMap();
            CreateMap<Movie, UpdateMovieDto>().ReverseMap();

            #endregion Movie
            CreateMap<CinemaEntity, CreateCinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, CinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, UpdateCinemaDto>().ReverseMap();


            #region Seat Mappings

            CreateMap<Seat, SeatDto>()
            .ForMember(x => x.Cinema, o => o.MapFrom(s => s.Cinema))
            .ReverseMap();
            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();

            #endregion Seat
        }
    }
}
