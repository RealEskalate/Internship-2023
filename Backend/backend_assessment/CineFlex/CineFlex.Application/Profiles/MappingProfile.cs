﻿using AutoMapper;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Features.Common;

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


            CreateMap<Seat, SeatDto>().ReverseMap();
            CreateMap<Seat, DeleteSeatDto>().ReverseMap();
            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();
        }
    }
}
