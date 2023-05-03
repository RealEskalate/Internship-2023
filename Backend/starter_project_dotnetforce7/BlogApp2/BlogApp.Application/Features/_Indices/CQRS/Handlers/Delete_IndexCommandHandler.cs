using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Handlers
{
    public class Delete_IndexCommandHandler : IRequestHandler<Delete_IndexCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_IndexCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Delete_IndexCommand request, CancellationToken cancellationToken)
        {
            var _Index = await _unitOfWork._IndexRepository.Get(request.Id);

            if (_Index == null)
                throw new NotFoundException(nameof(_Index), request.Id);

            await _unitOfWork._IndexRepository.Delete(_Index);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
