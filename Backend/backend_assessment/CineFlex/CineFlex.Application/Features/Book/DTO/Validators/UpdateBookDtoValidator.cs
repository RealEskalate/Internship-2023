using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.DTO.Validators
{
    public class UpdateBookDtoValidator:AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            Include(new IBookDtoValidator());
            RuleFor(a => a.Id)
           .NotNull()
           .WithMessage("{PropertyName} must be present");

        }
    }
    }

