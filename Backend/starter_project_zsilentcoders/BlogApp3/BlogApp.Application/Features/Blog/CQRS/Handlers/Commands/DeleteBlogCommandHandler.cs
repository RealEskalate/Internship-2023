using System.ComponentModel.DataAnnotations;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Responses;
using MediatR;

namespace Application.Features.Blog.Handlers.Commands;

public class DeleteBlogCommandHandler: IRequestHandler<DeleteBlogCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit>();
        
        var validator = new DeleteBlogDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.DeleteBlogDto);
       
        if (validationResult.IsValid == true){
            var blog = await _unitOfWork.BlogRepository.Get(request.DeleteBlogDto.Id);
            await _unitOfWork.BlogRepository.Delete(blog);
            if (await _unitOfWork.Save() > 0)
            {
                
                response.Message = "Deletion Successful!";
                response.Value = new Unit();
            }
            else
            {
                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
        }else{
            response.Success = false;
            response.Message = "Deletion Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        
        return response;
    }
}
