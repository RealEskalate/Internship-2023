using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery,BaseCommandResponse<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<PostDto>> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<PostDto>();
            var post = await _unitOfWork.PostRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<PostDto>(post);

            return response;
        }
    }
}
