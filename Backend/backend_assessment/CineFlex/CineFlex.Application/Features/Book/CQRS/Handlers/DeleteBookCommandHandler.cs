using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Books.CQRS.Commands;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Handlers;
public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookToDelete = await _bookRepository.Get(request.Id);

        if (bookToDelete == null)
            throw new NotFoundException(nameof(Book), request.Id);
        foreach (var seat in bookToDelete.Seats)
        {
            seat.BookId = null;
            await _unitOfWork.SeatRepository.Update(seat);
        }
        await _bookRepository.Delete(bookToDelete);
        return Unit.Value;
    }
}
