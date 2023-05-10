using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Tags.CQRS.Queries;
using BlogApp.Application.Features._Tags.DTOs;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.CQRS.Handlers
{
    public class getTagDetailQueryHandler : IRequestHandler<getTagDetailQuery, BaseResponse<_TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public getTagDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse <_TagDto>> Handle(getTagDetailQuery request, CancellationToken cancellationToken)
        {


            bool exists = await _unitOfWork._TagRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(_Tag), request.Id);
                return new BaseResponse<_TagDto>
                {
                    Success = false,
                    Message = "Tag Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };
            }
            var tag = await _unitOfWork._TagRepository.Get(request.Id);
            return new BaseResponse<_TagDto>
            {
                Success = true,
                Message = "Tag Fetch Success",
                Data = _mapper.Map<_TagDto>(tag)
            };


        }

        Task<BaseResponse<_TagDto>> IRequestHandler<getTagDetailQuery, BaseResponse<_TagDto>>.Handle(getTagDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
