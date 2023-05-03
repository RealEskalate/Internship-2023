using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

     public  CreateCommentCommandHandler(ICommentRepository commentRepository,IMapper mapper)
    {
        _commentRepository =  commentRepository;
        _mapper = mapper;
        
    }
    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    
      {
        var validator = new CreateCommentDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CommentDto);

        if (validatorResult.IsValid == false){
            throw new ValidationException(validatorResult.ToString()); 
        }

        var comment = _mapper.Map<Comment>(request.CommentDto);
        comment = await _commentRepository.Add(comment);

         return comment.Id;
      
    }
}
