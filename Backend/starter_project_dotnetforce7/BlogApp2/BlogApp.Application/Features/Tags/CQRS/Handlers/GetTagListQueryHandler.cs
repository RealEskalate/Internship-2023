using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, Result<List<TagDto>>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Result<List<TagDto>>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<List<TagDto>>();
            var tags = await _unitOfWork.TagRepository.GetAll();

            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<TagDto>>(tags);

            return response;
        }
    }
}