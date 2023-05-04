using BlogApp.Application.Features.Common;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public interface IThumbnailUrlDTO
    {
        public string? ThumbnailImageUrl { get; set; }
        public static bool IsValidUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri? outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }

}