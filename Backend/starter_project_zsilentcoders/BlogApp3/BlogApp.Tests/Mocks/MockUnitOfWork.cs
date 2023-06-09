using BlogApp.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockUserRepo = MockUserRepository.GetUserRepository();
            var mockBlogRepo = MockBlogRepository.GetBlogRepository();
            var mockTagRepo = MockTagRepository.GetTagRepository();
            mockUow.Setup(r => r.TagRepository).Returns(mockTagRepo.Object);
            var mockReviewRepo = MockReviewRepository.GetReviewRepository();
            var mockBlogRateRepo = MockBlogRateRepository.GetBlogRateRepository();
            
            
            var mockCommentRepo = MockCommentRepository.GetCommentRepository();
            mockUow.Setup(r => r._UserRepository).Returns(mockUserRepo.Object);
            mockUow.Setup(r => r.BlogRepository).Returns(mockBlogRepo.Object);
            mockUow.Setup(r=>r.ReviewRepository).Returns(mockReviewRepo.Object);
            mockUow.Setup(r => r.BlogRateRepository).Returns(mockBlogRateRepo.Object);

            mockUow.Setup(r => r.Save()).ReturnsAsync(1);
            mockUow.Setup(r => r.BlogRateRepository).Returns(mockBlogRateRepo.Object);
            mockUow.Setup(r => r._CommentRepository).Returns(mockCommentRepo.Object);
            return mockUow;
        }
    }
}

