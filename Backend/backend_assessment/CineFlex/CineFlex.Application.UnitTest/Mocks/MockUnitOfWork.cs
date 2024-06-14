using BlogApp.Application.UnitTest.Mocks;
using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace CineFlex.Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockSeatRepo = MockSeatRepository.GetSeatRepository();
            var mockCinemaRepo = MockCinemaRepository.GetCinemaRepository();

            mockUow.Setup(r => r.SeatRepository).Returns(mockSeatRepo.Object);
            mockUow.Setup(r => r.CinemaRepository).Returns(mockCinemaRepo.Object);

    

            mockUow.Setup(r => r.Save()).ReturnsAsync( 1);


            return mockUow;

        }


    }
}
