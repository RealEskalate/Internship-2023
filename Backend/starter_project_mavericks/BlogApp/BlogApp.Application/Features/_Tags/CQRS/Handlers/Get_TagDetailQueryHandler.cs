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
    public class Get_TagDetailQueryHandler : IRequestHandler<Get_TagDetailQuery, _TagDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_TagDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<_TagDto> Handle(Get_TagDetailQuery request, CancellationToken cancellationToken)
        {
            var _Tag = await _unitOfWork._TagRepository.Get(request.Id);
            return _mapper.Map<_TagDto>(_Tag);
        }
    }
}
