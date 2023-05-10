using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.UnitTest.Mocks;
using BlogApp.Domain;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace BlogApp.Application.UnitTests.Mocks
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
                    ReviewContent = "Good work",
                    BlogId = 1,
                    isResolved = true
                },

                new Review
                {

                    Id = 2,
                    ReviewerId = 2,
                    ReviewContent = "Terrible code",
                    BlogId = 2,
                    isResolved = true
                },

                 new Review
                {

                    Id = 3,
                    ReviewerId = 2,
                    ReviewContent = "Cool! ",
                    BlogId = 2,
                    isResolved = true
                }
            };

            var mockRepo = new Mock<IReviewRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(reviews);

            mockRepo.Setup(r => r.Add(It.IsAny<Review>())).ReturnsAsync((Review Review) =>
            {   
                Review.Id = reviews.Count() + 1;
                reviews.Add(Review);
                MockUnitOfWork.changes += 1;
                return Review;
            }); 

            mockRepo.Setup(r => r.Update(It.IsAny<Review>())).Callback((Review Review) =>
            {
                var newReviews = reviews.Where((r) => r.Id != Review.Id);
                reviews = newReviews.ToList();
                reviews.Add(Review);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Review>())).Callback((Review Review) =>
            {
                if (reviews.Remove(Review))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var review = reviews.FirstOrDefault((r) => r.Id == Id);
                return review != null;
            });


            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {   
                return reviews.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}
