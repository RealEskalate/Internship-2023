 
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public   UpdateCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }

    public async Task<Result<Unit>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {

        var validator = new UpdateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var comment = await _unitOfWork._CommentRepository.Get(request.CommentDto.Id);

            if (comment is null)
                throw new NotFoundException(nameof(comment), request.CommentDto.Id);

            _mapper.Map(request.CommentDto, comment);

            await _unitOfWork._CommentRepository.Update(comment);
            await _unitOfWork.Save();

            return new Result<Unit>();
    }
}
