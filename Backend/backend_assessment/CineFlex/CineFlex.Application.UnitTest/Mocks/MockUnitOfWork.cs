
using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockSeatRepo = MockSeatRepository.GetSeatRepository();

            mockUow.Setup(c => c.SeatRepository).Returns(mockSeatRepo.Object);

            return mockUow;
            
        }
        
    }
}