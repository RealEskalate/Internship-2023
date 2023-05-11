using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Reviews.DTOs;

public class UpdateReviewDto : BaseDto
{
    public string Comment { get; set; }
    public bool IsResolved { get; set; } 
}