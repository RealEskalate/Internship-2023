using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class GetCinemaQueryHandler : IRequestHandler<GetCinemaQuery, BaseCommandResponse<CinemaDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetCinemaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<CinemaDto>> Handle(GetCinemaQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.CinemaRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(Cinema), request.Id);
                return new BaseCommandResponse<CinemaDto>
                {
                    Success = false,
                    Message = "Cinema Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var cinema = await _unitOfWork.CinemaRepository.Get(request.Id);
            return new BaseCommandResponse<CinemaDto>
            {
                Success = true,
                Message = "Cinema Fetch Success",
                Value = _mapper.Map<CinemaDto>(cinema)
            };
        }
       
       
    }

}
