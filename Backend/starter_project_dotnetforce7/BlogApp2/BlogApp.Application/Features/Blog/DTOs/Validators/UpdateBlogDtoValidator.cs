using BlogApp.Application.Features.Blogs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators
{
    public class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogDtoValidator()
        {
            Include(new IBlogDtoValidator());

            // RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
