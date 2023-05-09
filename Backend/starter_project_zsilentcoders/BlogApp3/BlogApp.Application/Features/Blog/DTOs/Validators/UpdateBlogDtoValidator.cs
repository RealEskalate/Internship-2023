using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blog.DTOs.Validators
{
    public class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Id)
           .GreaterThan(0)
           .MustAsync(async (id, token) => await unitOfWork.BlogRepository.Exists(id)).WithMessage($"Blog not found");
        } 
    }
}
