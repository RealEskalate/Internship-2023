using MediatR;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Features.Authentication.DTOs.Validators;
using CineFlex.Domain.Models;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers
{
    public class UserSignUpCommandHandler : IRequestHandler<UserSignUpCommand, BaseCommandResponse<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserSignUpCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<UserDTO>> Handle(UserSignUpCommand command, CancellationToken cancellationToken)
        {
            
            var validator = new UserSignUpDtoValidator();
            var validationResult = await validator.ValidateAsync(command.SignUpDTO);
            if(!validationResult.IsValid){
                return new BaseCommandResponse<UserDTO>{
                    Success=false,
                    Errors=validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
            AppUser user = _mapper.Map<AppUser>(command.SignUpDTO);
            
            var temp = await _unitOfWork.UserRepository.RegisterUserAsync(user);
            
            await _unitOfWork.Save();
            
            if(!temp.Succeeded){
                return new BaseCommandResponse<UserDTO>{
                    Success=false,
                    Errors=temp.Errors.Select(error => error.Description).ToList()
                }; 
            }

            return new BaseCommandResponse<UserDTO>{
                Success=true,
                Value=_mapper.Map<UserDTO>(user)
            };
            
        }
    }
}
