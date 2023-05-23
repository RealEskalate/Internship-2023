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
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Features.Seats.DTOs;

namespace CineFlex.Application.Profiles
{
    public class MappingProfile : Profile
    {
        private readonly IUnitOfWork _unitOfWork;
        
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
            
            #region Seats 
            
            CreateMap<Seat, SeatDetailsDto>()
                .ForMember(dest => dest.Movie,
                    opt => opt.MapFrom(src => src.Movie.Id))
                .ForMember(dest => dest.Cinema,
                    opt => opt.MapFrom(src => src.Cinema.Id));
            
            #endregion Seats



            CreateMap<Booking, BookingDetailDto>()
                .ForMember(dest => dest.Seat,
                    opt => opt.MapFrom(src => src.Seat.Id));
        }
    }
}
