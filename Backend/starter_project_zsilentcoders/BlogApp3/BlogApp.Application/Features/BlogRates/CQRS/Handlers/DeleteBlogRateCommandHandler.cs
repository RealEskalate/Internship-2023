﻿﻿using System.ComponentModel.DataAnnotations;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs.Validators;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using AutoMapper;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using BlogApp.Application.Features.BlogRates.DTOs.Validators;

namespace Application.Features.BlogRates.Handlers.Commands;

public class DeleteBlogRateCommandHandler : IRequestHandler<DeleteBlogRateCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteBlogRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(DeleteBlogRateCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit>();

        var validator = new DeleteBlogRateDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.DeleteBlogRateDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Deletion Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            

            var blogRate = await _unitOfWork.BlogRateRepository.GetBlogRateByBlogAndRater(request.DeleteBlogRateDto.BlogId, request.DeleteBlogRateDto.RaterId);
            await _unitOfWork.BlogRateRepository.Delete(blogRate);
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
        }

        return response;
    }

   
}