using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Blogs.DTOs;
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
    public class getTagDetailQueryHandler : IRequestHandler<getTagDetailQuery, BaseResponse<TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public getTagDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse <TagDto>> Handle(getTagDetailQuery request, CancellationToken cancellationToken)
        {


            bool exists = await _unitOfWork.TagRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(Tag), request.Id);
                return new BaseResponse<TagDto>
                {
                    Success = false,
                    Message = "Tag Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };
            }
            var tag = await _unitOfWork.TagRepository.Get(request.Id);
            return new BaseResponse<TagDto>
            {
                Success = true,
                Message = "Tag Fetch Success",
                Data = _mapper.Map<TagDto>(tag)
            };


        }

        Task<BaseResponse<TagDto>> IRequestHandler<getTagDetailQuery, BaseResponse<TagDto>>.Handle(getTagDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
