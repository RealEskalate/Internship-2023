using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators
{
    public class ImageUrlValidator: AbstractValidator<IThumbnailUrlDTO>
    {
        public static bool IsValidUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri? outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }

        public ImageUrlValidator()
        {            
            RuleFor(blog => blog.ThumbnailImageUrl)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .Must(IsValidUri).WithMessage("{PropertyName} must be a valid URI");
        }

    }
}