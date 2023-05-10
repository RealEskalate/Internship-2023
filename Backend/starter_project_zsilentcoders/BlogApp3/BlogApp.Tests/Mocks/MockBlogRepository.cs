using BlogApp.Application.Contracts.Persistence;
using Moq;

namespace BlogApp.Tests.Mocks;

public static class MockBlogRepository
{
    public static Mock<IBlogRepository> GetBlogRepository()
    {
        var blogs = new List<BlogApp.Domain.Blog>
        {
            new ()
            {
                Id=1,
                AuthorId = 1,
                Title = "Title of Blog 1",
                Content = "Content of Blog 1",
            },
            
            new ()
            {
                Id=2,
                AuthorId = 2,
                Title = "Title of Blog 2",
                Content = "Content of Blog 2",
            }
        };

        var mockRepo = new Mock<IBlogRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(blogs);
        
        mockRepo.Setup(r => r.Add(It.IsAny<BlogApp.Domain.Blog>())).ReturnsAsync((BlogApp.Domain.Blog blog) =>
        {
            blog.Id = blogs.Count() + 1;
            blogs.Add(blog);
            return blog; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Blog>())).Callback((Domain.Blog blog) =>
        {
            var newBlogs = blogs.Where((r) => r.Id != blog.Id);
            blogs = newBlogs.ToList();
            blogs.Add(blog);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Blog>())).Callback((Domain.Blog blog) =>
        {
            if (blogs.Exists(b => b.Id == blog.Id))
                blogs.Remove(blogs.Find(b => b.Id == blog.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var rate = blogs.FirstOrDefault((r) => r.Id == id);
            return rate != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return blogs.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}