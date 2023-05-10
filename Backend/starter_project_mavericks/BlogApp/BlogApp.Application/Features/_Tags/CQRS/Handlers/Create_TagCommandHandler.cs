using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
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
    public class Create_TagCommandHandler : IRequestHandler<Create_TagCommand, BaseResponse<Nullable<int>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Create_TagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Nullable<int>>> Handle(Create_TagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<Nullable<int>>();
            var validator = new Create_TagDtoValidator();
            var validationResult = await validator.ValidateAsync(request._TagDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Tag = _mapper.Map<_Tag>(request._TagDto);

                Tag = await _unitOfWork._TagRepository.Add(Tag);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Data = Tag.Id;
            }

            return response;
        }
    }
}
