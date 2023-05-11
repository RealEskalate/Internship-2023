using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Commands;

public class UpdateTagCommand : IRequest<Result<UpdateTagDto?>>
{
    public UpdateTagDto UpdateTagDto { get; set; }
}