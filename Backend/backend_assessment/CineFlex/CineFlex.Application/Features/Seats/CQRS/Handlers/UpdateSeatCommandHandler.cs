using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.DTOs.Validators;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, BaseCommandResponse<Unit>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<Unit>();


            var validator = new UpdateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateSeatDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var seat = await _unitOfWork.SeatRepository.Get(request.updateSeatDto.Id);
                
                if (seat == null)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    return response;
                }
                _mapper.Map(request.updateSeatDto, seat);

                await _unitOfWork.SeatRepository.Update(seat);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    response.Value = Unit.Value;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }
            }

            return response;

        }
    }
}
