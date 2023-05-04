using BlogApp.Application.Features.Comments.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.DTOs.Validators
{
    public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentDtoValidator()
        {
            Include(new ICommentDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
