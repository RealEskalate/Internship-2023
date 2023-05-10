using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.UnitTest.Mocks;
using BlogApp.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {   var mockUow = new Mock<IUnitOfWork>();
            var mockRateRepo = MockRateRepository.GetRateRepository();
            var mockTagRepo = MockTagRepository.GetTagRepository();
            var mockBlogRepo = MockBlogRepository.GetBlogRepository();
            var mockCommentRepo = MockCommentRepository.GetCommentRepository();
            var mockReviewRepo = UnitTests.Mocks.MockReviewRepository.GetReviewRepository();

            mockUow.Setup(r => r.ReviewRepository).Returns(mockReviewRepo.Object);
            mockUow.Setup(r => r.RateRepository).Returns(mockRateRepo.Object);
            mockUow.Setup(t => t.TagRepository).Returns(mockTagRepo.Object);
            mockUow.Setup(r => r.CommentRepository).Returns(mockCommentRepo.Object);

            mockUow.Setup(r => r.BlogRepository).Returns(mockBlogRepo.Object);

            mockUow.Setup(r => r.Save()).ReturnsAsync(1);
            
            return mockUow;

    }

     
}
}
