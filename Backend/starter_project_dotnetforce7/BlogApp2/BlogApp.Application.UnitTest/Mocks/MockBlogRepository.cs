using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockBlogRepository
    {
        public static Mock<IBlogRepository> GetBlogRepository()
        {
            var Blogs = new List<Blog>
            {
                 new Blog
                {
                    Id = 1,
                    Title = "blog title 1",
                    Content = "Blog Content",
                    CoverImage = "blog image",
                    PublicationStatus= true
                    
                },

                new Blog
                {
                     Id = 1,
                    Title = "blog title21",
                    Content = "Blog Content",
                    CoverImage = "blog image",
                    PublicationStatus= true

                }
            };

            var mockRepo = new Mock<IBlogRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Blogs);

            mockRepo.Setup(r => r.Add(It.IsAny<Blog>())).ReturnsAsync((Blog Blog) =>
            {
                Blog.Id = Blogs.Count() + 1;
                Blogs.Add(Blog);
                MockUnitOfWork.changes += 1;
                return Blog;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Blog>())).Callback((Blog Blog) =>
            {
                var newBlogs = Blogs.Where((r) => r.Id != Blog.Id);
                Blogs = newBlogs.ToList();
                Blogs.Add(Blog);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Blog>())).Callback((Blog Blog) =>
            {
                 if (Blogs.Remove(Blog))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return Blogs.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}
