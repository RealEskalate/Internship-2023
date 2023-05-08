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
        await _unitOfWork.BlogRepository.Delete(await _unitOfWork.BlogRepository.Get(request.DeleteBlogDto.Id));
    
            
            if (await _unitOfWork.Save() > 0 && validationResult.IsValid == true){
                response.Message = "Deletion Successful!";
                response.Value = new Unit();
            }else{

                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        return response;
    }
    }
