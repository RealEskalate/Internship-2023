using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, BaseCommandResponse<MovieDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<MovieDto>> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<MovieDto>();
            var movie = await _unitOfWork.MovieRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Movie retrieval Successful";
            response.Value = _mapper.Map<MovieDto>(movie);

            return response;
        }
    }
}
