using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;

using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, BaseCommandResponse<List<PostDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<PostDto>>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<PostDto>>();
            var posts = await _unitOfWork.PostRepository.GetAll();
       
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<PostDto>>(posts);

            return response;
        }
    }
}
