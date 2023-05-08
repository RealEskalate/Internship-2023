using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Users.CQRS.Commands;
using BlogApp.Application.Features.Users.DTOs.Validators;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Users.CQRS.Handlers
{
    public class Update_UserCommandHandler : IRequestHandler<Update_UserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Update_UserCommand request, CancellationToken cancellationToken)
        {
            var validator = new Update_UserDtoValidator();
            var validationResult = await validator.ValidateAsync(request._UserDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var user = await _unitOfWork._UserRepository.Get(request._UserDto.Id);

            if (user is null)
                throw new NotFoundException(nameof(User), request._UserDto.Id);

            _mapper.Map(request._UserDto, user);

            await _unitOfWork._UserRepository.Update(user);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
