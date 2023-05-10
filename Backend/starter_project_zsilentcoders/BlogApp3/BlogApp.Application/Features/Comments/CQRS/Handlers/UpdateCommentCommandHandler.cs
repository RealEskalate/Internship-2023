 
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Comments.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Comments.CQRS.Handlers;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Result<UpdateCommentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public   UpdateCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }

    public async Task<Result<UpdateCommentDto>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {

        var response = new Result<UpdateCommentDto?>();
        var validator = new UpdateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CommentDto);
 
        if (validationResult.IsValid == true){
            var comment = await _unitOfWork._CommentRepository.Get(request.CommentDto.Id);
            _mapper.Map(request.CommentDto, comment);

            await _unitOfWork._CommentRepository.Update(comment);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Updation Successful!";
                    // response.Value = new Unit();
                    response.Value = _mapper.Map<UpdateCommentDto>(comment);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Updation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }
        }
        else{

            response.Success = false;
            response.Message = "Updation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }

        return response;
    }
}
