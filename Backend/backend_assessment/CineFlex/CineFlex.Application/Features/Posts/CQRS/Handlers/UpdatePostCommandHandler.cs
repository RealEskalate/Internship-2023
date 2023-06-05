using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.DTOs.Validators;


using CineFlex.Application.Responses;
using MediatR;

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
			var response = new BaseCommandResponse<Unit>();

			var validator = new UpdatePostDtoValidator();
			var validationResult = await validator.ValidateAsync(request.updatePostDto);

			if (validationResult.IsValid == false)
			{
				response.Success = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{
				var Post = await _unitOfWork.PostRepository.Get(request.updatePostDto.Id);

				if (Post is null)
					return null;
				   
				_mapper.Map(request.updatePostDto, Post);

				await _unitOfWork.PostRepository.Update(Post);
			  
				if (await _unitOfWork.Save() > 0)
				{
					response.Success = true;
					response.Message = "Updated Successful";
					
				}
				else
				{
					response.Success = false;
					response.Message = "Update Failed";
				}    
			}

			return response;
		}
	}
}
