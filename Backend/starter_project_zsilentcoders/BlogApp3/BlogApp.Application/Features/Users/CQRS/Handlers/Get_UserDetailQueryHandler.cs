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
    public class Get_UserDetailQueryHandler : IRequestHandler<Get_UserDetailQuery, _UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_UserDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<_UserDto> Handle(Get_UserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork._UserRepository.Get(request.Id);
            return _mapper.Map<_UserDto>(user);
        }
    }
}
