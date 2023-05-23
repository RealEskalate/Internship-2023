using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Users.CQRS.Commands;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Users.CQRS.Handlers
{
    public class Delete_UserCommandHandler : IRequestHandler<Delete_UserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Delete_UserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork._UserRepository.Get(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            await _unitOfWork._UserRepository.Delete(user);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
