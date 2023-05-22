using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, BaseCommandResponse<List<MovieDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<MovieDto>>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<MovieDto>>();
            var movies = await _unitOfWork.MovieRepository.GetAll();

            response.Success = true;
            response.Message = "Movies retrieval Successful";
            response.Value = _mapper.Map<List<MovieDto>>(movies);

            return response;
        }
    }
}
