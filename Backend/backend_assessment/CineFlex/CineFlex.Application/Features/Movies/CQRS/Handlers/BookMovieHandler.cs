using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.DTOs.Validators;
using CineFlex.Application.Features.Movies.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class BookMovieCommandHandler : IRequestHandler<BookMovieCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(BookMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new BookMovieDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookMovieDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Movie booking failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var movie = _mapper.Map<Movie>(request.BookMovieDto);

                movie = await _unitOfWork.MovieRepository.Add(movie);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Booking successful";
                    response.Value = movie.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Booking failed";
                }
            }

            return response;
        }
    }
}
