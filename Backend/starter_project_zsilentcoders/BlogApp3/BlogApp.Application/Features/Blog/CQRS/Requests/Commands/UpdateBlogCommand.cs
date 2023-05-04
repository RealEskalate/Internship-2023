namespace BlogApp.Application.Features.Blog.CQRS.Requests.Commands;

public class UpdateBlogCommand : IRequest<Unit>
{
    public UpdateBlogDto UpdateBlogDto { get; set; }
}
