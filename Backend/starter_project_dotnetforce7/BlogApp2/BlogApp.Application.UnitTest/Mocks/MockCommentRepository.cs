using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.UnitTest.Mocks;
using BlogApp.Domain;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace BlogApp.Application.UnitTests.Mocks
{
    public static class MockCommentRepository
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var Comments = new List<Comment>
            {
                  new Comment
                {
                    Id = 1,
                    Content = "Sample Content",
                    UserId = 1,
                    BlogId = 1,
                },

                 new Comment
                 {
                     Id = 2,
                     Content = "Sample Content",
                     UserId = 2,
                     BlogId = 2,
                 }
            };

            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Comments);

            mockRepo.Setup(r => r.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
            {
                comment.Id = Comments.Count() + 1;
                Comments.Add(comment);
                return comment;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Comment>())).Callback((Comment comment) =>
            {
                var newRates = Comments.Where((r) => r.Id != comment.Id);
                Comments = newRates.ToList();
                Comments.Add(comment);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Comment>())).Callback((Comment comment) =>
            {
                Comments.Remove(comment);

            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var rate = Comments.FirstOrDefault((r) => r.Id == Id);
                return rate != null;
            });


            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return Comments.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}
