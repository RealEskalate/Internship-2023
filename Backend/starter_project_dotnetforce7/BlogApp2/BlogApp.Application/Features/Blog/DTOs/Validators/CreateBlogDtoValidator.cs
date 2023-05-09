using BlogApp.Application.Features.Blogs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators

{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            Include(new IBlogDtoValidator());
        }
    }

}
