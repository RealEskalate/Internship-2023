using MediatR;
using AutoMapper;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Authentication.DTOs.Validators;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers
{
    public class UserSignInCommandHandler : IRequestHandler<UserSignInCommand, BaseCommandResponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserSignInCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<string>> Handle(UserSignInCommand command, CancellationToken cancellationToken)
        {
            
            var validator = new UserSignInDtoValidator();
            var validationResult = await validator.ValidateAsync(command.SignInDTO);
            if(!validationResult.IsValid){
                return new BaseCommandResponse<string>{
                    Success=false,
                    Errors=validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
            
            var valid = await _unitOfWork.UserRepository.ValidateUserAsync(command.SignInDTO);
            
            if(!valid){
                return new BaseCommandResponse<string>{
                    Success=false,
                    Errors=new List<string>{"Invalid credentials"}
                }; 
            }

            return new BaseCommandResponse<string>{
                Success=true,
                Value=await _unitOfWork.UserRepository.CreateTokenAsync()
            };
            
        }
    }
}
