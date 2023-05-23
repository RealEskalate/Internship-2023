using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.DTO.Validators;
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



namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCinemaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateCinemaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CinemaDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var cinema = _mapper.Map<CinemaEntity>(request.CinemaDto);

                cinema = await _unitOfWork.CinemaRepository.Add(cinema);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successfull";
                    response.Value = cinema.Id;
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
    
       
