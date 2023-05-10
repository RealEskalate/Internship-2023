using MediatR;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Tags.CQRS.Queries;

public class GetTagDetailsQuery: IRequest<Result<TagDetailsDto?>>
{
    public int Id { get; set; }
}