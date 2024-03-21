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
            

            RuleFor(p => p.Commenter).NotNull().WithMessage("{PropertyName} must be present").NotEmpty().WithMessage("{PropertyName} must not be empty ");
             RuleFor(p => p.Content).NotNull().WithMessage("{PropertyName} must be present").NotEmpty().WithMessage("{PropertyName} must not be empty ");;
        }
    }
}
