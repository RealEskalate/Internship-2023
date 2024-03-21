using FluentValidation;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators
{
    public class CreateBlogDtoValidator: AbstractValidator<CreateBlogDTO>
    {
        public CreateBlogDtoValidator()
        {
            RuleFor(blog => blog.Title)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(blog => blog.Content)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            When(blog => blog.ThumbnailImageUrl != null, ()=>{
                Include(new ImageUrlValidator());
            });
        }

    }
}