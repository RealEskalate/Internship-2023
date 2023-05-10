using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Tags.CQRS.Queries;
using BlogApp.Application.Features._Tags.DTOs;
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
    public class getTagListQueryHandler : IRequestHandler<getTagListQuery, BaseResponse<List<_TagDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public getTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<_TagDto>>> Handle(getTagListQuery request, CancellationToken cancellationToken)
        {
            var tag = await _unitOfWork._TagRepository.GetAll();

            if (tag == null || tag.Count == 0)
            {
                // Return an error response if there are no tags found
                return new BaseResponse<List<_TagDto>>
                {
                    Success = false,
                    Message = "No tags found."
                };
            }
            else
            {
                // Map the tag list to a response DTO and return a success response
                return new BaseResponse<List<_TagDto>>
                {
                    Success = true,
                    Data = _mapper.Map<List<_TagDto>>(tag)
                };
            }
        }
    }
}
