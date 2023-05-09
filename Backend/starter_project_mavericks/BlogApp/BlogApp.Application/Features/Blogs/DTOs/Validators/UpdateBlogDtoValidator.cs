using BlogApp.Domain;
using FluentValidation;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators
{
    public class UpdateBlogDtoValidator: AbstractValidator<UpdateBlogDTO>
    {
        public UpdateBlogDtoValidator()
        {
            RuleFor(blog => blog.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            When(blog => blog.Title != null, ()=>{
                RuleFor(blog => blog.Title)
                    .NotEmpty().WithMessage("{PropertyName} cannot be empty;")
                    .MaximumLength(255).WithMessage("{PropertyName} must be less than 255 characters");
            });

            When(blog => blog.Content != null, ()=>{
                RuleFor(blog => blog.Content)
                    .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                    .MaximumLength(255).WithMessage("{PropertyName} must be less than 255 characters");
            });

            When(blog => blog.ThumbnailImageUrl != null, ()=>{
                Include(new ImageUrlValidator());
            });
        }
    }
}