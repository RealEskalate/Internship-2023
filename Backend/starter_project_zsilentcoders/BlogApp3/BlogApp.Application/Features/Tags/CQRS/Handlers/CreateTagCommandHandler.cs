using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Tags.DTOs;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Result<CreateTagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateTagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<CreateTagDto>();
            var validator = new CreateTagDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTagDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Tag = _mapper.Map<Tag>(request.CreateTagDto);

                Tag = await _unitOfWork.TagRepository.Add(Tag);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<CreateTagDto>(Tag);
            }

            return response;
        }
    }
}
