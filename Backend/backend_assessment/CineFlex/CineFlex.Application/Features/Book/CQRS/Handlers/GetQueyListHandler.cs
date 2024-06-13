using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Book.CQRS.Queries;
using CineFlex.Application.Features.Book.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class GetQueyListHandler: IRequestHandler<GetBookListQuery, BaseCommandResponse<List<BookDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetQueyListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<List<BookDto>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<BookDto>>();
            var seats = await _unitOfWork.BookRepository.GetAll();

            response.Success = true;
            response.Message = "Movies retrieval Successful";
            response.Value = _mapper.Map<List<BookDto>>(seats);

            return response;
        }
    }
}
