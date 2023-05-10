using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Tests.Mocks
{
    public class MockReviewRepository
    {
        public static Mock<IReviewRepository> GetReviewRepository()
        {
            var reviews = new List<Domain.Review>{
                new (){
                    Id=1,
                    BlogId = 1,
                    Comment = "Comment of the review",
                    ReviewerId = 1,
                },

                new ()
                {
                    Id=2,
                    BlogId = 2,
                    Comment = "Comment of the review",
                    ReviewerId = 2,
                }
            };

            var mockRepo = new Mock<IReviewRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(reviews);

            mockRepo.Setup(r => r.Add(It.IsAny<Review>())).ReturnsAsync((Review review) =>
            {
                reviews.Add(review);
                return review;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Domain.Review>())).Callback((Domain.Review review) =>
            {
                var newReviews = reviews.Where((r) => r.Id != review.Id);
                reviews = newReviews.ToList();
                reviews.Add(review);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Review>())).Callback((Domain.Review review) =>
            {
                if (reviews.Exists(b => b.Id == review.Id))
                    reviews.Remove(reviews.Find(b => b.Id == review.Id)!);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var reviewId = reviews.FirstOrDefault((r) => r.Id == id);
                return reviewId != null;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
            {
                return reviews.FirstOrDefault((r) => r.Id == id);
            });

            mockRepo.Setup(r => r.GetAllByReviewerId(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                    return reviews.Where(r => r.ReviewerId == id).ToList();
            });


            return mockRepo;
        }
    }
}
