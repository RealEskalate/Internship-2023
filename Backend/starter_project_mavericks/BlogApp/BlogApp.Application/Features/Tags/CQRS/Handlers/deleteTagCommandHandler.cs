using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class deleteTagCommandHandler : IRequestHandler<deleteTagCommand, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public deleteTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(deleteTagCommand request, CancellationToken cancellationToken)
        {
            var _Tag = await _unitOfWork.TagRepository.Get(request.Id);

            if (_Tag == null)
            {
                var error = new NotFoundException(nameof(Tag), request.Id);
                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag deletion failed",
                    Errors = new List<string> { error.Message }
                };
            }

            await _unitOfWork.TagRepository.Delete(_Tag);
            bool success = await _unitOfWork.Save() > 0;
            if(success == false)
            {
                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag deletion failed",
                    Errors = new List<string> { "failed to save to database" }
                };
            }

            return new BaseResponse<Unit>
            {
                Success = true,
                Message = "Tag deletion successful"
            };
        }
    }
}
