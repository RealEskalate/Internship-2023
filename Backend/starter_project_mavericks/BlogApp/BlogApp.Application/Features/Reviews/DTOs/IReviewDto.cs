
namespace BlogApp.Application.Features.Reviews.DTOs;
public interface IReviewDto
{
    string ReviewerId { get; set; }
    string Comment { get; set; }
    bool IsResolved { get; set; }
    int BlogId { get; set; }
    
    
}