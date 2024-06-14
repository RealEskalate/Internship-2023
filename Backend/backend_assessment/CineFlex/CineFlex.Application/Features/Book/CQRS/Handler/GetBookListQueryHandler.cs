using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Book.CQRS.Query;
using CineFlex.Application.Features.Book.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, BaseCommandResponse<List<BookDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<BookDto>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {

            var book = await _unitOfWork.BookRepository.GetAll();

            if (book == null || book.Count == 0)
            {
                return new BaseCommandResponse<List<BookDto>>
                {
                    Success = false,
                    Message = "No Book found."
                };
            }
            else
            {
                return new BaseCommandResponse<List<BookDto>>
                {
                    Success = true,
                    Value = _mapper.Map<List<BookDto>>(book)
                };
            }
        }
    }
    }

