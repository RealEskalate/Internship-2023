using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class GetTagDetailQueryHandler : IRequestHandler<GetTagDetailQuery, Result<TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTagDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }


        public async Task<Result<TagDto>> Handle(GetTagDetailQuery request, CancellationToken cancellationToken)
        {

            var response = new Result<TagDto>();
            var tag = await _unitOfWork.TagRepository.Get(request.Id);

            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<TagDto>(tag);

            return response;

        }
    }
}