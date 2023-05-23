using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace CineFlex.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockSeatRepo = MockSeatRepository.GetSeatRepository();

            mockUnitOfWork.Setup(r => r.SeatRepository).Returns(mockSeatRepo.Object);

            mockUnitOfWork.Setup(r => r.Save()).ReturnsAsync(1);
            return mockUnitOfWork;
        }
    }
}

