using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.DTOs.Validators;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

 public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand,Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public   DeleteCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
         _unitOfWork= unitOfWork;
        _mapper = mapper;
        
    }

    public async Task<Result<Unit>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    { 

        var response = new Result<Unit>();
        
        var validator = new DeleteCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CommentDto);
        
        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Deletion Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            response.Message = "Deletion Successful!";
            response.Value = new Unit();
        
            await _unitOfWork._CommentRepository.Delete(await _unitOfWork._CommentRepository.Get(request.CommentDto.Id));
            await _unitOfWork.Save();
        }
         
        return response;
         
         
    }
}
