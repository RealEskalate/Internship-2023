using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Tags.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.CQRS.Handlers
{
    public class Delete_TagCommandHandler : IRequestHandler<Delete_TagCommand, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_TagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(Delete_TagCommand request, CancellationToken cancellationToken)
        {
            var _Tag = await _unitOfWork._TagRepository.Get(request.Id);

            if (_Tag == null)
            {
                var error = new NotFoundException(nameof(_Tag), request.Id);
                return new BaseResponse<Unit>
                {
                    Success = false,
                    Message = "Tag deletion failed",
                    Errors = new List<string> { error.Message }
                };
            }

            await _unitOfWork._TagRepository.Delete(_Tag);
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
