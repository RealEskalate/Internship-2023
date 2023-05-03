using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Handlers
{
    public class Get_IndexDetailQueryHandler : IRequestHandler<Get_IndexDetailQuery, _IndexDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_IndexDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<_IndexDto> Handle(Get_IndexDetailQuery request, CancellationToken cancellationToken)
        {
            var _Index = await _unitOfWork._IndexRepository.Get(request.Id);
            return _mapper.Map<_IndexDto>(_Index);
        }
    }
}
