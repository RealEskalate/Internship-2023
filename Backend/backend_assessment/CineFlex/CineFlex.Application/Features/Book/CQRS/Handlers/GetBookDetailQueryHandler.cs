using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Book.CQRS.Queries;
using CineFlex.Application.Features.Book.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class GetBookDetailQueryHandler: IRequestHandler<GetBookDetailQuery, BaseCommandResponse<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<BaseCommandResponse<BookDto>> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<BookDto>();
            var book = await _unitOfWork.BookRepository.Get(request.Id);
            if (book == null)
            {
                response.Success = false;
                response.Message = "Book retrieval Unsuccesfull";
                response.Value = null;
            }
            else
            {
                response.Success = true;
                response.Message = "Book retrieval Successful";
                response.Value = _mapper.Map<BookDto>(book);
            }

            return response;
        }
    }
}