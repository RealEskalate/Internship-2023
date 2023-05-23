using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace BlogApp.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockSeatRepo = MockSeatRepository.GetBlogRepository();
            mockUow.Setup(r => r.SeatRepository).Returns(mockSeatRepo.Object);
            mockUow.Setup(r => r.Save()).ReturnsAsync(1);
            return mockUow;
        }
    }
}

