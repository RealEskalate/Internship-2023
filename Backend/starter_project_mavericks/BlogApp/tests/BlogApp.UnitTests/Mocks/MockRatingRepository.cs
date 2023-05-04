using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;
using Newtonsoft.Json.Linq;

namespace BlogApp.UnitTests.Mocks;

public class MockRatingRepository
{
    public static Mock<IRatingRepository> GetRatingRepository()
    {
        var ratings = new List<Rating>
            {
                new Rating
                {
                    Id = 1,
                    BlogId = 1,
                    RaterId = 0,
                    Rate = 2,
                },
                new Rating
                {
                    Id = 2,
                    BlogId = 1,
                    RaterId = 1,
                    Rate = 10,
                },
                new Rating
                {
                    Id = 3,
                    BlogId = 2,
                    RaterId = 1,
                    Rate = 2,
                },
            };

        var mockRepo = new Mock<IRatingRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(ratings);

        mockRepo.Setup(r => r.Add(It.IsAny<Rating>())).ReturnsAsync((Rating rating) =>
        {
            ratings.Add(rating);
            return rating;
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Rating>())).Callback<Rating>(rating =>
        {
            var r = ratings.FirstOrDefault(x => x.Id == rating.Id);
            r.Rate = rating.Rate;
        });

        mockRepo.Setup(r => r.GetByBlog(It.IsAny<int>())).Returns((int blogId) =>
        {
            return ratings
                .Where(q => q.BlogId == blogId).ToList();
        });

        mockRepo.Setup(r => r.GetByBlogAndRater(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((int blogId, int raterId) =>
        {
            return ratings
                .FirstOrDefault(q => q.BlogId == blogId && q.RaterId == raterId);
        });
        return mockRepo;
    }
}