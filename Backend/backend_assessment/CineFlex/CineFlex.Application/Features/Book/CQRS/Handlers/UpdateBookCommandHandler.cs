using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Books.CQRS.Commands;
using CineFlex.Application.Features.Books.DTO.Validator;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Handlers;
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBookDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateBookDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var bookToUpdate = await _bookRepository.Get(request.UpdateBookDto.Id);

        if (bookToUpdate == null)
            throw new NotFoundException(nameof(Book), request.UpdateBookDto.Id);

        _mapper.Map(request.UpdateBookDto, bookToUpdate);

        await _bookRepository.Update(bookToUpdate);
        return Unit.Value;
    }
}
