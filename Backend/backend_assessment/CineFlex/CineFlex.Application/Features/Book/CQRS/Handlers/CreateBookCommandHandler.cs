using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Book.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            
            var seat = _mapper.Map<CineFlex.Domain.Seats>(request.bookingDto);

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
            return response;
        }
    }
}
