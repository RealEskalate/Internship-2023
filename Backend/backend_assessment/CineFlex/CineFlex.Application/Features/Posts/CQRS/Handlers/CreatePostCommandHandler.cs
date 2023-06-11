using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreatePostDto);
            if (validationResult.IsValid == false)
            {
                return new BaseCommandResponse<int>()
                {
                    Success = false,
                    Message = "Creation Failed",
                    Errors = validationResult.Errors.Select(r => r.ErrorMessage).ToList()
                };
            }
            var post = _mapper.Map<Post>(request.CreatePostDto);
            await _unitOfWork.PostRepository.Add(post);
            if (await _unitOfWork.Save() == 0)
            {
                return new BaseCommandResponse<int>()
                {
                    Success = false,
                    Message = "Server Error",

                };


            }
            return new BaseCommandResponse<int>()
            {
                Success = true,
                Message = "Successfully Created",
                Value = post.Id,

            };

        }
    }
}
