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
using CineFlex.Application.Features.User.DTOs;
using CineFlex.Application.Models.Identity;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.MoviesBooking.DTOs;

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

            #region MovieBooking Mappings
            CreateMap<MovieBooking, MovieBookingDto>().ReverseMap();
            CreateMap<MovieBooking, CreateMovieBookingDto>().ReverseMap();
            CreateMap<MovieBooking, UpdateMovieBookingDto>().ReverseMap();
            #endregion MovieBooking

            #region Cinema Mappings
            CreateMap<CinemaEntity, CreateCinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, CinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, UpdateCinemaDto>().ReverseMap();
            #endregion Cinema


            #region Seat Mappings
            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, SeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();
            #endregion Seat

            CreateMap<RegisterDto, RegistrationRequest>().ReverseMap();
            CreateMap<RegisterDto, RegistrationResponse>().ReverseMap();



        }
    }
}
