using AutoMapper;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Domain;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Bookings.DTOs;

namespace CineFlex.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Movie Mappings

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateSeatDto>().ReverseMap();

            CreateMap<Movie, UpdateMovieDto>().ReverseMap();

            #endregion Movie

            #region Cinema Mappings
            CreateMap<CinemaEntity, CreateCinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, CinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, UpdateCinemaDto>().ReverseMap();
            CreateMap<CinemaEntity, CinemaProfile>();
            #endregion  Cinema

            #region Seat Mappgins
            CreateMap<Seat, SeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatStatusDto>().ReverseMap();
            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, SeatProfile>();
            #endregion Seat

            #region Booking Mappgins
            CreateMap<Booking, BookingDto>()
                .ForMember(bkd => bkd.MovieName, bk => bk.MapFrom(bk => bk.Movie.Title))
                .ForMember(bkd => bkd.CinemaName, bk => bk.MapFrom(bk => bk.Cinema.Name))
                .ForMember(bkd => bkd.Seats, bk => bk.MapFrom(bk => bk.Seats.Select(st => st.SeatNo).ToList()));
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, BookingDetailDto>();
            #endregion Booking
        }
    }
}
