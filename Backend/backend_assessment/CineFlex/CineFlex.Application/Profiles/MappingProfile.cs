using AutoMapper;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Cinemas.DTO;
using CineFlex.Application.Features.Cinemas.Dtos;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Domain.Models;
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
            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();
            CreateMap<Cinema, CinemaDto>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();

            #region _seat Mappings

            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, SeatListDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();

            #endregion _seat

            #region _user Mappings

            CreateMap<AppUser, UserSignUpDTO>().ReverseMap();
            CreateMap<AppUser, UserDTO>().ReverseMap();

            #endregion _user
        }
    }
}
