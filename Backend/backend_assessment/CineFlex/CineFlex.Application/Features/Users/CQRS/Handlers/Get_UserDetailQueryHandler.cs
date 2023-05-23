using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Users.CQRS.Queries;
using CineFlex.Application.Features.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Users.CQRS.Handlers
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
