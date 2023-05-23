using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Books.DTO;
using CineFlex.Application.Features.Seats.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.DTO.Validator;
public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateBookDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(p => p)
                .MustAsync(async (p, token) =>
                {
                    foreach (var id in p.SeatIds)
                    {
                        var seat = await _unitOfWork.SeatRepository.Get(id);
                        if (seat.Book != null)
                        {
                            return false;
                        }
                    }
                    return true;
                })
                .WithMessage("{PropertyName} seat taken.");
    }


}
