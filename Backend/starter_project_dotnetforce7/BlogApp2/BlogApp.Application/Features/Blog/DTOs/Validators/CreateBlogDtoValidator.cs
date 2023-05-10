using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators

{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            Include(new IBlogDtoValidator());

             RuleFor(p => p.File)
            .Must(file => file == null || IsImageFile(file))
            .WithMessage("{PropertyName} must be null or an image file.");
        }

          private bool IsImageFile(IFormFile file)
            {
          return file == null || (file.ContentType != null && file.ContentType.Contains("image/")); 
            }
    }

}
