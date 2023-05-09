
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Queries
{
    public class GetTagDetailQuery : IRequest<Result<TagDto>>
    {
        public int Id { get; set; }
        
    }
}