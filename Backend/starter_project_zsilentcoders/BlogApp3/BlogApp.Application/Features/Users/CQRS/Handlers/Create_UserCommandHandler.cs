using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Users.CQRS.Commands;
using BlogApp.Application.Features.Users.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Users.CQRS.Handlers
{
    public class Create_UserCommandHandler : IRequestHandler<Create_UserCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Create_UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Create_UserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new Create_UserDtoValidator();
            var validationResult = await validator.ValidateAsync(request._UserDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var user = _mapper.Map<User>(request._UserDto);

                user = await _unitOfWork._UserRepository.Add(user);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = user.Id;
            }

            return response;
        }
    }
}
