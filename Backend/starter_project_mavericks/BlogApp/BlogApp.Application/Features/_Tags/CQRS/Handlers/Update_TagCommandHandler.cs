using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Tags.CQRS.Commands;
using BlogApp.Application.Features._Tags.DTOs.Validators;
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
    public class Update_TagCommandHandler : IRequestHandler<Update_TagCommand, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_TagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(Update_TagCommand request, CancellationToken cancellationToken)
        {
            var validator = new Update_TagDtoValidator();
            var validationResult = await validator.ValidateAsync(request._TagDto);

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

            bool tagExists = await _unitOfWork._TagRepository.Exists(request._TagDto.Id);

            if (tagExists == false)
            {
                var error = new NotFoundException(nameof(_Tag), request._TagDto.Id);

                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag update failed",
                    Errors = new List<string> { error.Message }
                };
            }


            var Tag  = _mapper.Map<_Tag>(request._TagDto);

            await _unitOfWork._TagRepository.Update(Tag);
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
