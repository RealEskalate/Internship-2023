﻿using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class CreateSeatCommandHandler: IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SeatDto);

            

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Seat Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var seat = _mapper.Map<Seat>(request.SeatDto);

                seat = await _unitOfWork.SeatRepository.Add(seat);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = seat.Id;
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
