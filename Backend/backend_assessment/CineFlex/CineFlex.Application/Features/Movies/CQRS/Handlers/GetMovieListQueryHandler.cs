using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers;

public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, BaseCommandResponse<List<MovieDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetMovieListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<List<MovieDto>>> Handle(GetMovieListQuery request,
        CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<List<MovieDto>>();
        IReadOnlyList<Movie> movies = new List<Movie>();

        if (request.query == null)
            movies = await _unitOfWork.MovieRepository.GetAll();
        else
            movies = await _unitOfWork.MovieRepository.GetMoviesByTitle(request.query);

        response.Success = true;
        response.Message = "Movies retrieval Successful";
        response.Value = _mapper.Map<List<MovieDto>>(movies);

        return response;
    }
}