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
        public UpdateBlogDtoValidator()
        {
            
        }
    }
}
