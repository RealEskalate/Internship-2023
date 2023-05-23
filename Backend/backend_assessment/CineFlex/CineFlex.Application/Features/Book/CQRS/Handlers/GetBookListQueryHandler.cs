using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Books.CQRS.Queries;
using CineFlex.Application.Features.Books.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Handlers;
public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, List<BookDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookListQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAll();

        return _mapper.Map<List<BookDto>>(books);
    }
}
