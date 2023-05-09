using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;

namespace BlogApp.UnitTests.Mocks
{
    public class MockBlogRepository
    {
        public static Mock<IBlogRepository> GetBlogRepository()
        {
            var blogs = new List<Blog>{
                new Blog{
                    Id=1,
                    Title="First Blog",
                    Content="This is the content of the first blog",
                    ThumbnailImageUrl="https://www.blogImages.com/firstBlog.jpg",
                    Status=PublicationStatus.Published,
                    Rating=4
                },
                new Blog{
                    Id=2,
                    Title="Second Blog",
                    Content="This is the content of the second blog",
                    ThumbnailImageUrl="https://www.blogImages.com/secondBlog.jpg",
                    Status=PublicationStatus.Published,
                    Rating=3
                },
                new Blog{
                    Id=3,
                    Title="Third Blog",
                    Content="This is the content of the third blog",
                    ThumbnailImageUrl="https://www.blogImages.com/thirdBlog.jpg",
                    Status=PublicationStatus.NotPublished,
                    Rating=2
                },
                new Blog{
                    Id=4,
                    Title="Fourth Blog",
                    Content="This is the content of the fourth blog",
                    ThumbnailImageUrl="https://www.blogImages.com/fourthBlog.jpg",
                    Status=PublicationStatus.NotPublished,
                    Rating=1
                }
            };

            var blogRepo = new Mock<IBlogRepository>();
            
            blogRepo.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((int id) => blogs.FirstOrDefault(o => o.Id == id));

            blogRepo.Setup(repo => repo.Add(It.IsAny<Blog>())).ReturnsAsync((Blog blog)=>{
                blog.Id = blogs.Count+1;
                blogs.Add(blog);
                return blog;
            });

            blogRepo.Setup(repo => repo.Delete(It.IsAny<Blog>()))
                                        .Callback<Blog>(blog => blogs.RemoveAll(b => b.Id == blog.Id));

            blogRepo.Setup(repo => repo.Update(It.IsAny<Blog>())).Callback<Blog>(blog => {
                Blog? blogTemp = blogs.FirstOrDefault(b => b.Id == blog.Id);
                if(blogTemp!=null){
                    blogTemp.Title = blog.Title;
                    blogTemp.Content = blog.Content;
                    blogTemp.ThumbnailImageUrl = blog.ThumbnailImageUrl;
                    blogTemp.Status = blog.Status;
                }
            });

            return blogRepo;
        }
    }
}