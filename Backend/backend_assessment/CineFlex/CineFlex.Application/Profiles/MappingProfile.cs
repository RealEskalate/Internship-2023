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
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Booking.DTOs;
using CineFlex.Application.Features.Authentication.DTOs;

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

            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();

            CreateMap<BookingEntity, CreateBookingDto>().ReverseMap();

            #region Authentication Mappings
            CreateMap<SignupFormDto, User>().ReverseMap();
            CreateMap<User, SignUpResponse>().ReverseMap();
            #endregion Authentication Mappings
        }
    }
}
