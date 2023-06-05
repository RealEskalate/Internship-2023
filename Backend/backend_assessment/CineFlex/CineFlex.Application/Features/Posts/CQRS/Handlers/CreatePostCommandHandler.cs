using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreatePostDto);
            if(validationResult.IsValid == false){
                return new BaseCommandResponse<int>(){
                    Success = false,
                    Message = "creation failed",
                    Errors = validationResult.Errors.Select(r=>r.ErrorMessage).ToList()
                };
            }
            var post = _mapper.Map<Post>(request.CreatePostDto);
            await _unitOfWork.PostRepository.Add(post);
            if( await _unitOfWork.Save() == 0 ){
                return new BaseCommandResponse<int>(){
                    Success=false,
                    Message="server error",
        
                };


            }
            return new BaseCommandResponse<int>(){
                Success = true,
                Message = "Created successfully",
                Value = post.Id,

            };

        }
    }
}