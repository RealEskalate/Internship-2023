using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Tags.CQRS.Queries;
using BlogApp.Application.Features._Tags.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.CQRS.Handlers
{
    public class getTagListQueryHandler : IRequestHandler<Get_TagListQuery, List<_TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public getTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<_TagDto>> Handle(Get_TagListQuery request, CancellationToken cancellationToken)
        {
            var _Tags = await _unitOfWork._TagRepository.GetAll();
            return _mapper.Map<List<_TagDto>>(_Tags);
        }
    }
}
