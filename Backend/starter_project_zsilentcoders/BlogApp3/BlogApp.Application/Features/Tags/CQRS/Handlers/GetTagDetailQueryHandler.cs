using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Features.Tags.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class GetTagDetailQueryHandler : IRequestHandler<GetTagDetailQuery, TagDto>
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;

        public GetTagDetailQueryHandler(ITagRepository TagRepository, IMapper mapper)
        {
            _TagRepository = TagRepository;
            _mapper = mapper;
        }
        public async Task<TagDto> Handle(GetTagDetailQuery request, CancellationToken cancellationToken)
        {
            var Tag = await _TagRepository.Get(request.Id);
            return _mapper.Map<TagDto>(Tag);
        }
    }
}
