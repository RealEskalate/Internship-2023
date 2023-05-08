using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Features.Blog.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<Unit?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit?>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit?>();
        var validator = new UpdateBlogDtoValidator();
        var validationResult = await validator.ValidateAsync(request.UpdateBlogDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Updation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            response.Message = "Deletion Successful!";
            response.Value = new Unit();

            await _unitOfWork.BlogRepository.Update(await _unitOfWork.BlogRepository.Get(request.UpdateBlogDto.Id));
            await _unitOfWork.Save();
        }

        return response;
    
    }
}
