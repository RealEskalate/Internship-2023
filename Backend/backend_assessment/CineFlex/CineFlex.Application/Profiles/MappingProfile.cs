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
using CineFlex.Application.Features.MovieBookings.DTOs;

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

            
            #region Seat Mappings

            CreateMap<Seat, SeatDetailDto>().ReverseMap();
            CreateMap<Seat, SeatListDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();
            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            
            #endregion Movie

            #region Seat Mappings

            CreateMap<MovieBooking, MovieBookingDto>().ReverseMap();
            CreateMap<MovieBooking, UpdateMovieBookingDto>().ReverseMap();
            CreateMap<MovieBooking, CreateMovieBookingDto>().ReverseMap();
            
            #endregion Movie

            CreateMap<CinemaEntity, CreateCinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, CinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, UpdateCinemaDto>().ReverseMap();
        }
    }
}
