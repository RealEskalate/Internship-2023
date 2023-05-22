using BlogApp.Application.Features.Common;


namespace BlogApp.Application.Features.Reviews.DTOs
{
    public class ReviewDto : BaseDto
    {
        public int ReviewerId { get; set; }
        public string ReviewContent { get; set; }
        public int BlogId { get; set; }
        public bool? isResolved { get; set; }

       
    }
}
