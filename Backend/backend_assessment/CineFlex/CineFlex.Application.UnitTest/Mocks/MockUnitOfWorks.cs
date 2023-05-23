using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace CineFlex.Application.UnitTest.Mocks;

public static class MockUnitOfWork
{
    public static int changes = 0;
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockSeatRepo = MockSeatRepository.GetSeatRepository();
        mockUow.Setup(r => r.SeatRepository).Returns(mockSeatRepo.Object);

        mockUow.Setup(r => r.Save()).ReturnsAsync(() =>
        {
            var temp = changes;
            changes = 0;
            return temp;
        });

        return mockUow;
    }

}