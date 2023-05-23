﻿using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Queries;

public class GetMovieDetailQuery : IRequest<BaseCommandResponse<MovieDto>>
{
    public int Id { get; set; }
}