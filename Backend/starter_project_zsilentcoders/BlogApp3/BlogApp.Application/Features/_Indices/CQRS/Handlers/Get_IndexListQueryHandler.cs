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
    public class Get_IndexListQueryHandler : IRequestHandler<Get_IndexListQuery, List<_IndexDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_IndexListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<_IndexDto>> Handle(Get_IndexListQuery request, CancellationToken cancellationToken)
        {
            var _Indices = await _unitOfWork._IndexRepository.GetAll();
            Console.Write(_Indices);
            return _mapper.Map<List<_IndexDto>>(_Indices);
        }
    }
}
