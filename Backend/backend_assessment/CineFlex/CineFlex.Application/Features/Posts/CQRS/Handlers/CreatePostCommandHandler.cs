using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.DTO.Validators;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;



namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreatePostDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PostDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var post = _mapper.Map<Post>(request.PostDto);

                post = await _unitOfWork.PostRepository.Add(post);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successfull";
                    response.Value = post.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";

                }
                
            }
            return response;
        }

    }
}
    
       
