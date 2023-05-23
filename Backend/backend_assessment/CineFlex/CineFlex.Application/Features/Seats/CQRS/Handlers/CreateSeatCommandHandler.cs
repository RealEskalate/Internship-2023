using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserAccessor _userAccessor;

        public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userAccessor = userAccessor;

        }

        public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateSeatDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.SeatDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {

                var currentUser = await _userAccessor.GetCurrentUser();

                if (currentUser == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }

                var Seat = _mapper.Map<SeatEntity>(request.SeatDto);
                Seat.AppUser = currentUser;

                Seat = await _unitOfWork.SeatRepository.Add(Seat);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successfull";
                    response.Value = Seat.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";

                }

            }
            return response;
        }

    }
}


