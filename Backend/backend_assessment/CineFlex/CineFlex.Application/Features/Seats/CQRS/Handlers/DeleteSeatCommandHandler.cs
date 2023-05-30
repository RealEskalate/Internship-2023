using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSeatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (seat == null)
                throw new NotFoundException(nameof(Seat), request.Id);

            await _unitOfWork.SeatRepository.Delete(seat);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }

