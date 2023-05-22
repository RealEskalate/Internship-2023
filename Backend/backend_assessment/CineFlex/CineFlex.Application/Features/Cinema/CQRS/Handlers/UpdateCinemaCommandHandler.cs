using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.DTO.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCinemaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();
            var validator = new UpdateCinemaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateCinemaDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
           
            var cinema = await _unitOfWork.CinemaRepository.Get(request.updateCinemaDto.Id);

            if (cinema == null)
            {
              response.Success = true;
              response.Message = "no cinema found by this id";
            }
            _mapper.Map(request.updateCinemaDto, cinema);
            await _unitOfWork.CinemaRepository.Update(cinema);
            if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Successfully Updated";
                    response.Value = Unit.Value;
                }
            else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }

            return response;
        }
    }
}
