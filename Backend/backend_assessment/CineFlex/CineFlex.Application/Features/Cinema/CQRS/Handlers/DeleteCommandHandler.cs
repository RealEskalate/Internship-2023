using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class DeleteCommandHandler: IRequestHandler<DeleteCinemaCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();

            var cinema = await _unitOfWork.CinemaRepository.Get(request.Id);

            if (cinema is null)
            {
                response.Success = false;
                response.Message = "Delete Failed";
            }
            else
            {

                await _unitOfWork.CinemaRepository.Delete(cinema);


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
    

