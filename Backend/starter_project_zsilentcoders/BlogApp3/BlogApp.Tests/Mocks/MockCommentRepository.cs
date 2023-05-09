using BlogApp.Application.Contracts.Persistence;
using Moq;

namespace BlogApp.Tests.Mocks;

public class MockCommentRepository
{

     public static Mock<ICommentRepository> GetCommentRepository()
    {
        var comments = new List<BlogApp.Domain.Comment>
        {
            new ()
            {
                Id=1,
                CommenterId = 1,
                BlogId = 1,
                Content = "comment for Blog 1",
            },
            
            new ()
            {
                Id=2,
                CommenterId = 2,
                BlogId = 1,
                Content = "comment for Blog 1",
            }
        };

         var mockRepo = new Mock<ICommentRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);
        
        mockRepo.Setup(r => r.Add(It.IsAny<BlogApp.Domain.Comment>())).ReturnsAsync((BlogApp.Domain.Comment comment) =>
        {
            comment.Id = comments.Count() + 1;
            comments.Add(comment);
            return comment; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Comment>())).Callback((Domain.Comment comment) =>
        {
            var newComments = comments.Where((r) => r.Id != comment.Id);
            comments = newComments.ToList();
            comments.Add(comment);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Comment>())).Callback((Domain.Comment comment) =>
        
        {
            if (comments.Exists(b => b.Id == comment.Id))
                comments.Remove(comments.Find(b => b.Id == comment.Id)!);
        });

        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return comments.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}