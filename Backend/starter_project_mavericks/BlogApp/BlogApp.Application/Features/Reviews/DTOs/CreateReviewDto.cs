
namespace BlogApp.Application.Features.Reviews.DTOs;

public class CreateReviewDto : IReviewDto
{
    public string ReviewerId { get; set; }
    public string Comment { get; set; }
    public bool IsResolved { get; set; }=false;
    public int BlogId{ get; set; }

}