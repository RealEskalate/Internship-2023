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
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, List<TagDto>>
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;

        public GetTagListQueryHandler(ITagRepository TagRepository, IMapper mapper)
        {
            _TagRepository = TagRepository;
            _mapper = mapper;
        }

        public async Task<List<TagDto>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var Tags = await _TagRepository.GetAll();
            Console.Write(Tags);
            return _mapper.Map<List<TagDto>>(Tags);
        }
    }
}
