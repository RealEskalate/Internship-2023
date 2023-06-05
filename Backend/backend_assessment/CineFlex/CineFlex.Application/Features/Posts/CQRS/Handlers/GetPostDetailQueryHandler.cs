using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class GetPostDetailQueryHandler:IRequestHandler<GetPostDetailQuery,BaseCommandResponse<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IUnitOfWork unitOfWork , IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<PostDto>> Handle(GetPostDetailQuery request, CancellationToken cancellationToken){
            var post = await _unitOfWork.PostRepository.Get(request.Id);
            if(post == null){
                var error = new NotFoundException(nameof(post),request.Id);
                return new BaseCommandResponse<PostDto>(){
                    Success= false,
                    Message = "not found",
                    Errors = new List<string>(){
                        $"{error}"
                    }
                };
            }
            return new BaseCommandResponse<PostDto>(){
                
                Success = true,
                Message = "Retrieved successfully",
                Value = _mapper.Map<PostDto>(post)

            };
        }
        
    }
}