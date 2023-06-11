using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdatePostDto);
            if (validationResult.IsValid == false)
            {
                return new BaseCommandResponse<Unit>()
                {
                    Success = false,
                    Message = "Failed to Update",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var post = await _unitOfWork.PostRepository.Get(request.UpdatePostDto.Id);
            if (post == null)
            {
                var error = new NotFoundException(nameof(post), request.UpdatePostDto.Id);
                return new BaseCommandResponse<Unit>()
                {
                    Success = false,
                    Message = "Not Exist",
                    Errors = new List<string>(){
                        $"{error}"
                    }
                };

            }
            _mapper.Map(post, request.UpdatePostDto);
            await _unitOfWork.PostRepository.Update(post);
            if (await _unitOfWork.Save() == 0)
            {
                return new BaseCommandResponse<Unit>()
                {
                    Success = false,
                    Message = "Server Error"
                };
            }
            return new BaseCommandResponse<Unit>()
            {
                Success = true,
                Message = "Updated Successfully"

            };
        }
    }
}
