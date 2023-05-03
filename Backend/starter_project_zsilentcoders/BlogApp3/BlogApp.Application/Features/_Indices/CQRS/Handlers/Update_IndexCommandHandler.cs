using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Handlers
{
    public class Update_IndexCommandHandler : IRequestHandler<Update_IndexCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_IndexCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Update_IndexCommand request, CancellationToken cancellationToken)
        {
            var validator = new Update_IndexDtoValidator();
            var validationResult = await validator.ValidateAsync(request._IndexDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var _Index = await _unitOfWork._IndexRepository.Get(request._IndexDto.Id);

            if (_Index is null)
                throw new NotFoundException(nameof(_Index), request._IndexDto.Id);

            _mapper.Map(request._IndexDto, _Index);

            await _unitOfWork._IndexRepository.Update(_Index);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
