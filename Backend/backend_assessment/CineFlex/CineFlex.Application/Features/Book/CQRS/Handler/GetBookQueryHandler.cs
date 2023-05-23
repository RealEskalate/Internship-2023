using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Features.Book.CQRS.Query;
using CineFlex.Application.Features.Book.DTO;

namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BaseCommandResponse<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<BookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.BookRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(Domain.Book), request.Id);
                return new BaseCommandResponse<BookDto>
                {
                    Success = false,
                    Message = "Book Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var Book = await _unitOfWork.BookRepository.Get(request.Id);
            return new BaseCommandResponse<BookDto>
            {
                Success = true,
                Message = "Book Fetch Success",
                Value = _mapper.Map<BookDto>(Book)
            };
        }
       
       
    }

}
