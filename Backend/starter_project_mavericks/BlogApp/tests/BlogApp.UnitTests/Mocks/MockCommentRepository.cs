using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;
using Newtonsoft.Json.Linq;

namespace BlogApp.UnitTests.Mocks;

public class MockCommentRepository
{
    public static Mock<ICommentRepository> GetCommentRepository()
    {
        var comments = new List<Comment>
            {
                new Comment
                {
                   Id = 1,
                    BlogId = "Hello",
                    Commenter = "Manchester United",
                    Content = "new",
                },
                new Comment
                {
                   Id = 2,
                    BlogId = "Hello",
                    Commenter = "Manchester United 2",
                    Content = "new",
                },
                 new Comment
                {
                   Id = 3,
                    BlogId = "Hello",
                    Commenter = "Manchester United3",
                    Content = "new",
                },
            };

        var mockRepo = new Mock<ICommentRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);

        mockRepo.Setup(r => r.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
        {
            comments.Add(comment);
            return comment;
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Comment>())).Callback<Comment>(comment =>
        {
            var c = comments.FirstOrDefault(x => x.Id == comment.Id);
            c.Content = comment.Content;
        });

       

        
        return mockRepo;
    }
}