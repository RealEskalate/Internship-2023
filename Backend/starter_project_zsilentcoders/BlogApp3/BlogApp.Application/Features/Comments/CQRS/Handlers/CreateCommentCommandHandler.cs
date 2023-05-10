using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;


public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result<CommentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

     public  CreateCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork =  unitOfWork;
        _mapper = mapper;
        
    }
    public async Task<Result<CommentDto>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    
      {
            var response = new Result<CommentDto?>();
            var validator = new CreateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDto);

             
        if (validationResult.IsValid == true){
            var comment = _mapper.Map<Domain.Comment>(request.CommentDto);
            comment = await _unitOfWork._CommentRepository.Add(comment);
            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<CommentDto>(comment);
            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
        }
        else
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
      
        return response;



      
    }

    
}
