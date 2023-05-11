using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Queries;

public class GetTagListQuery : IRequest<Result<List<TagListDto>>>
{
}