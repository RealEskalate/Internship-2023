using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;
namespace BlogApp.UnitTests.Mocks
{
    public static class MockReviewRepository
    {

        public static Mock<IReviewRepository> GetReviewRepository()
        {
            var reviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    ReviewerId = 1,
                    Comment = "Good work",
                    BlogId = 1,
                    IsResolved = true
                },

                new Review
                {

                    Id = 2,
                    ReviewerId = 2,
                    Comment = "Terrible code",
                    BlogId = 2,
                    IsResolved = false
                },

                new Review
                {

                    Id = 3,
                    ReviewerId = 2,
                    Comment = "Cool! ",
                    BlogId = 2,
                    IsResolved = true
                }
            };

            var mockRepo = new Mock<IReviewRepository>();

            mockRepo.Setup(r => r.GetReviewDetail(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var review = reviews.FirstOrDefault(r => r.Id == Id);
                return review;
            });

            mockRepo.Setup(r => r.Add(It.IsAny<Review>())).ReturnsAsync((Review review) =>
            {
                review.Id = reviews.Count() + 1;
                reviews.Add(review);
                return review;


            });
            
            mockRepo.Setup(r => r.Update(It.IsAny<Review>())).Callback((Review review) =>
            { 
                Review? newReview = reviews.FirstOrDefault(r => r.Id == review.Id);
                if (newReview != null){
                    newReview.Comment = review.Comment;
                    newReview.IsResolved = review.IsResolved;
                }


            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Review>())).Callback((Review review) =>
            {
                var newReview = reviews.FirstOrDefault(r => r.Id == review.Id);
                if( newReview != null)
                reviews.Remove(newReview);

            });
            
            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var review = reviews.FirstOrDefault((r) => r.Id == Id);
                return review != null;
            });
            
            return mockRepo;

        }
    }
}
    
