using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{

    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public   UpdateCommentCommandHandler(ICommentRepository commentRepository,IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
          var validator = new UpdateCommentDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CommentDto);

         if (validatorResult.IsValid == false){
            throw new ValidationException(validatorResult.ToString()); 
        }
        var comment = await _commentRepository.Get(request.CommentDto.Id);

        _mapper.Map(request.CommentDto,comment);

        await _commentRepository.Update(comment);
        return Unit.Value;
    }
}
