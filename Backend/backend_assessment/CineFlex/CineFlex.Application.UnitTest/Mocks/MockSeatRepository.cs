using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace CineFlex.Application.UnitTest.Mocks
{
    public static class MockSeatRepository
    {
        public static Mock<ISeatRepository> GetSeatRepository()
        {
            var Seats = new List<SeatEntity>
            {
                 new SeatEntity
                {
                    IsTaken = false,
                    Id = 1
                },

                new SeatEntity
                {
                    IsTaken = false,
                    Id = 2
                }
            };

            var mockRepo = new Mock<ISeatRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Seats);

            mockRepo.Setup(r => r.Add(It.IsAny<SeatEntity>())).ReturnsAsync((SeatEntity Seat) =>
            {
                Seat.Id = Seats.Count() + 1;
                Seats.Add(Seat);
                MockUnitOfWork.changes += 1;
                return Seat;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<SeatEntity>())).Callback((SeatEntity Seat) =>
            {
                var newSeats = Seats.Where((r) => r.Id != Seat.Id);
                Seats = newSeats.ToList();
                Seats.Add(Seat);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<SeatEntity>())).Callback((SeatEntity Seat) =>
            {
                if (Seats.Remove(Seat))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return Seats.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}
