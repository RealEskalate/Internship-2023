using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;


public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

     public  CreateCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork =  unitOfWork;
        _mapper = mapper;
        
    }
    public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    
      {
          var response = new BaseCommandResponse();
            var validator = new CreateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var comment = _mapper.Map<Comment>(request.CommentDto);

                comment = await _unitOfWork._CommentRepository.Add(comment);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = comment.Id;
            }

            return response;





        
      
    }
}
