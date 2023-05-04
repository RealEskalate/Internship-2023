using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

 public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public   DeleteCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
         _unitOfWork= unitOfWork;
        _mapper = mapper;
        
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork._CommentRepository.Get(request.Id);

         if (comment == null){
            throw new NotFoundException(nameof(Comment),request.Id); 
        }

        await _unitOfWork._CommentRepository.Delete(comment);
        await _unitOfWork.Save();
        return Unit.Value;
         
    }
}
