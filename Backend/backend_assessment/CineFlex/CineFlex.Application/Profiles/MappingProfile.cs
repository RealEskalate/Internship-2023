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
using CineFlex.Application.Features.Books.DTO;
using TaskManagementSystem.Application.Models.Identity;

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

            CreateMap<Seat, UpdateSeatDto>().ReverseMap();
            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, SeatDto>().ReverseMap();

            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<ApplicationUser, RegistrationRequest>().ReverseMap();
            CreateMap<ApplicationUser, RegistrationResponse>().ReverseMap();
        }
    }
}
