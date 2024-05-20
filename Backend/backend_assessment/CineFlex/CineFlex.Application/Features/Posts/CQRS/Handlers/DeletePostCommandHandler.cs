using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.CQRS.Handlers
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePostCommandHandler(IUnitOfWork unitOfWork, AutoMapper.IMapper _mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.Get(request.Id);
            if (post == null)
            {
                var error = new NotFoundException(nameof(post), request.Id);
                return new BaseCommandResponse<Unit>()
                {
                    Success = false,
                    Message = "Not Exist",
                    Errors = new List<string>(){
                        $"{error}"
                    }
                };
            }
            await _unitOfWork.PostRepository.Delete(post);
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
                Message = "Successfully Deleted"
            };

        }
    }
}
