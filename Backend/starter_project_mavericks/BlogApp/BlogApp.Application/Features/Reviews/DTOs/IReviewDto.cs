namespace BlogApp.Application.Features.Reviews.DTOs;

public interface IReviewDto
{
    int ReviewerId { get; set; }
    int BlogId { get; set; }
    string Comment { get; set; }
    bool IsResolved { get; set; }
    
    
}