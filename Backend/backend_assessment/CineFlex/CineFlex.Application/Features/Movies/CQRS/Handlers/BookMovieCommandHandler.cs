
using Application.Contracts.Identity;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class BookMovieCommandHandler : IRequestHandler<BookMovieCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CineFlex.Domain.User> _userManager;
        private readonly IUserAccessor _userAccessor;

        public BookMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, 
        UserManager<CineFlex.Domain.User> userManager, IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }


        public async Task<BaseCommandResponse<int>> Handle(BookMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var user = await _userManager.Users.FirstOrDefaultAsync(x =>
           x.UserName == _userAccessor.GetUserName());

            var cinema = await _unitOfWork.CinemaRepository.Get(request.BookDto.cinemaId);
            var movie = await _unitOfWork.MovieRepository.Get(request.BookDto.MovieId);
            var seat = await _unitOfWork.SeatRepository.Get(request.BookDto.SeatNumber);

            if (movie == null || seat == null || cinema == null || seat.IsBooked == true)
            {
                response.Success = false;
                response.Message = "Movie booking failed.";
            }
            else
            {

                seat.IsBooked = true;
                seat.BookedBy = user;

                await _unitOfWork.SeatRepository.Update(seat);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Movie booked successfully.";
            }

            return response;

        }
    }
}