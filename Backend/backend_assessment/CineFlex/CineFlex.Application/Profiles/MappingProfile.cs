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
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Features.Seats.Dtos;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Features.Bookings.Dtos;

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

            CreateMap<SeatEntity, CreateSeatDto>().ReverseMap();
            CreateMap<SeatEntity, SeatDto>().ReverseMap();
            CreateMap<SeatEntity, UpdateSeatDto>().ReverseMap();


            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
    }
}
