using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Tags.DTOs;
using FluentValidation;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Result<UpdateTagDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateTagDto?>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {

        var response = new Result<UpdateTagDto?>();
        var validator = new UpdateTagDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateTagDto);

        if (validationResult.IsValid == true){
            var tag = await _unitOfWork.TagRepository.Get(request.UpdateTagDto.Id);
            _mapper.Map(request.UpdateTagDto, tag);

            await _unitOfWork.TagRepository.Update(tag);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Updation Successful!";
                    // response.Value = new Unit();
                    response.Value = _mapper.Map<UpdateTagDto>(tag);
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