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
using BlogApp.Application.Features.Blog.DTOs;

namespace BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<UpdateBlogDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateBlogDto?>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {

        var response = new Result<UpdateBlogDto?>();
        var validator = new UpdateBlogDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateBlogDto);

        if (validationResult.IsValid == true){
            var blog = await _unitOfWork.BlogRepository.Get(request.UpdateBlogDto.Id);
            _mapper.Map(request.UpdateBlogDto, blog);

            await _unitOfWork.BlogRepository.Update(blog);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Updation Successful!";
                    // response.Value = new Unit();
                    response.Value = _mapper.Map<UpdateBlogDto>(blog);
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