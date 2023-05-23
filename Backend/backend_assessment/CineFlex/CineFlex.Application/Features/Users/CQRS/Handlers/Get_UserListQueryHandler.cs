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
    public class Get_UserListQueryHandler : IRequestHandler<Get_UserListQuery, List<_UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_UserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<_UserDto>> Handle(Get_UserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork._UserRepository.GetAll();
            return _mapper.Map<List<_UserDto>>(users);
        }
    }
}
