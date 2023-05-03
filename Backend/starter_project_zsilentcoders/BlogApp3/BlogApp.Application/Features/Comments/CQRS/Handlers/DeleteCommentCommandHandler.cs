using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand,Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public   DeleteCommentCommandHandler(ICommentRepository commentRepository,IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.Id);

         if (comment == null){
            throw new NotFoundException(nameof(Comment),request.Id); 
        }

        await _commentRepository.Delete(comment);
        return Unit.Value;
         
    }
}
