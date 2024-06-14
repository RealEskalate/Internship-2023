using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.DTO.Validators
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            Include(new IBookDtoValidator());
            RuleFor(a => a.UserId)
           .NotNull()
           .WithMessage("{PropertyName} must be present");
        }

    }
}
