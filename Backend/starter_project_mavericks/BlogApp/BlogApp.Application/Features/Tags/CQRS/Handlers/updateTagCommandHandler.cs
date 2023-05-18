using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
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

namespace BlogApp.Application.Features._Tags.CQRS.Handlers
{
    public class updateTagCommandHandler : IRequestHandler<updateTagCommand, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public updateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(updateTagCommand request, CancellationToken cancellationToken)
        {
            var validator = new updateTagDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TagDto);

            if (validationResult.IsValid == false)
            {
                var error =  new ValidationException(validationResult);
                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag Update failed",
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            bool tagExists = await _unitOfWork.TagRepository.Exists(request.TagDto.Id);

            if (tagExists == false)
            {
                var error = new NotFoundException(nameof(Domain.Tag), request.TagDto.Id);

                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag update failed",
                    Errors = new List<string> { error.Message }
                };
            }


            var Tag  = _mapper.Map<Tag>(request.TagDto);

            await _unitOfWork.TagRepository.Update(Tag);
            bool success = await _unitOfWork.Save() > 0;
            if (success == false)
            {
                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag update failed",
                    Errors = new List<string> { "failed to save to database" }
                };
            }

            return new BaseResponse<Unit>
            {
                Success = true,
                Message = "Tag update successful"
            };
        }
    }
}
