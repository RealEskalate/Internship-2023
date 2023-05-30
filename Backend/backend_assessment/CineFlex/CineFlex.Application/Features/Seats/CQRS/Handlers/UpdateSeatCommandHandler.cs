using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSeatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateSeatDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var seat = await _unitOfWork.SeatRepository.Get(request.UpdateSeatDto.Id);

            if (seat is null)
                throw new NotFoundException(nameof(User), request.UpdateSeatDto.Id);

            _mapper.Map(request.UpdateSeatDto, seat);

            await _unitOfWork.SeatRepository.Update(seat);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }

