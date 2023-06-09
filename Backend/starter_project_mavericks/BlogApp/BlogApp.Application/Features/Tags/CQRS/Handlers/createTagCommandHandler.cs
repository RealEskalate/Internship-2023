﻿using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class createTagCommandHandler : IRequestHandler<createTagCommand, BaseResponse<Nullable<int>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public createTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Nullable<int>>> Handle(createTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<Nullable<int>>();
            var validator = new createTagDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TagDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Tag = _mapper.Map<Tag>(request.TagDto);

                Tag = await _unitOfWork.TagRepository.Add(Tag);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Data = Tag.Id;
            }

            return response;
        }
    }
}
