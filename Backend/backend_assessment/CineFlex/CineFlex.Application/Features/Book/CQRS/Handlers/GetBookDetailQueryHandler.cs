using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Books.CQRS.Queries;
using CineFlex.Application.Features.Books.DTO;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Handlers;
public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookDetailQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.Get(request.Id);

        if (book == null)
            throw new NotFoundException(nameof(Book), request.Id);

        return _mapper.Map<BookDto>(book);
    }
}
