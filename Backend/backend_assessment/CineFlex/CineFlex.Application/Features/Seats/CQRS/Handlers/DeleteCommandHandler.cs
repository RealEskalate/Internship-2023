﻿using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class DeleteCommandHandler: IRequestHandler<DeleteSeatCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IUserAccessor _userAccessor;


        public DeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;

        }

        public async Task<BaseCommandResponse<Unit>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();

            var Seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (Seat is null)
            {
                response.Success = false;
                response.Message = "Delete Failed";
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

                // if(currentUser.Role == Roles.UserRole){
                //     response.Success = false;
                //     response.Message = "UnAuthorized to Delete this Seat";
                //     return response;
                // }

                await _unitOfWork.SeatRepository.Delete(Seat);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                    response.Value = Unit.Value;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            }



            return response;
        }
    }
}
    

