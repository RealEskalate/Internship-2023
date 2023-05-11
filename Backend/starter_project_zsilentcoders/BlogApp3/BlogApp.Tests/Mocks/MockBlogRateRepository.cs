using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;

namespace BlogApp.Tests.Mocks;

public static class MockBlogRateRepository
{
    public static Mock<IBlogRateRepository> GetBlogRateRepository()
    {
        var blogRates = new List<BlogRate>
        {
            new ()
            {
                BlogId = 1,
                RaterId = 2,
                RateNo = 3,
            },

            new ()
            {
              BlogId = 2,
              RaterId = 3,
              RateNo = 4,
            }
        };
        
        var mockRepo = new Mock<IBlogRateRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(blogRates);

        mockRepo.Setup(r => r.Add(It.IsAny<BlogRate>())).ReturnsAsync((BlogRate blogRate) =>
        {
            blogRates.Add(blogRate);
            return blogRate;
        });

        mockRepo.Setup(r => r.Update(It.IsAny<BlogRate>())).Callback((BlogRate blogRate) =>
        {
            var newBlogRates = blogRates.Where((r) => r.Id != blogRate.Id);
            blogRates = newBlogRates.ToList();
            blogRates.Add(blogRate);
        });

        mockRepo.Setup(r => r.Delete(It.IsAny<BlogRate>())).Callback((BlogRate blogRate) =>
        {
            if (blogRate != null)
            {
                var index = blogRates.FindIndex(b => b.BlogId == blogRate.BlogId && b.RaterId == blogRate.RaterId);
                if (index != -1)
                {
                    blogRates.RemoveAt(index);
                }
            }
            
        });

        mockRepo.Setup(r => r.BlogExists(It.IsAny<int>())).ReturnsAsync((int blogId) =>
        {
            var rate = blogRates.FirstOrDefault((r) => r.BlogId == blogId);
            return rate != null;
        });
       
        mockRepo.Setup(r => r.RaterExists(It.IsAny<int>())).ReturnsAsync((int raterId) =>
        {
            var rate = blogRates.FirstOrDefault(r => r.RaterId == raterId);
            return rate != null;
        });

        mockRepo.Setup(r => r.GetBlogRatesByBlog(It.IsAny<int>())).ReturnsAsync((int blogId) =>
        {
            return blogRates.Where((r) => r.BlogId == blogId).ToList();
        });

        mockRepo.Setup(r => r.GetBlogRateByBlogAndRater(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((int blogId, int raterId) =>
        {
            
            var result = blogRates.FirstOrDefault(r => r.RaterId == raterId && r.BlogId == blogId);
            return result;
        });

        return mockRepo;
    }
}