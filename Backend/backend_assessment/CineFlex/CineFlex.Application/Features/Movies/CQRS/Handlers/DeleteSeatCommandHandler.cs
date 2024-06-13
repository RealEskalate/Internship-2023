using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteMovieCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();

            var movie = await _unitOfWork.MovieRepository.Get(request.Id);

            if (movie is null)
            {
                response.Success = false;
                response.Message = "Failed find a movie by that Id.";
            }
            else
            {

                await _unitOfWork.MovieRepository.Delete(movie);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Movie deleted Successful";
                    response.Value = movie.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Movie Deletion Failed";
                }
            }

            return response;
        }
    }
}
