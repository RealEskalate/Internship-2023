using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.BlogRates.DTOs;

public class DeleteBlogRateDto 
{
     public int BlogId { get; set; }
    public int RaterId { get; set; }
}