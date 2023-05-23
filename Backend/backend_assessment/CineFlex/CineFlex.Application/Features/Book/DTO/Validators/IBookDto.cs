using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.DTO.Validators
{
    public class IBookDtoValidator : AbstractValidator<IBookDto>
    {
        public IBookDtoValidator()
        {
            RuleFor(p => p.CinemaId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.MovieId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();


            RuleFor(p => p.SeatId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}

