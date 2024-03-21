using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class CreateMovieCommandHandler: IRequestHandler<CreateMovieCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateMovieDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MovieDto);

            

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Movie Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var movie = _mapper.Map<Movie>(request.MovieDto);

                movie = await _unitOfWork.MovieRepository.Add(movie);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = movie.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }

            }

            return response;
        }
    }
}
