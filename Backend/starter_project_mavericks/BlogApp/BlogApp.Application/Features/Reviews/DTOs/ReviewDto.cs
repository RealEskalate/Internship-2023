using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Reviews.DTOs;

public class ReviewDto : BaseDto,IReviewDto
{
    public int BlogId { get; set; }
    public int ReviewerId { get; set; }
    public string Comment { get; set; }
    public bool IsResolved { get; set; }
}