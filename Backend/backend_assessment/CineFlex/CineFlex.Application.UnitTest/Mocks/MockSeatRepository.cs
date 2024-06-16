
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockSeatRepository
    {
        public static Mock<ISeatRepository> GetSeatRepository()
        {

            var seats = new List<Seat>
            {
               new Seat
             {
                 Id = 1,
                 IsBooked = true,
                 SeatNumber = 1
             },

            new Seat
            {
                Id = 2,
                IsBooked = false,
                SeatNumber = 2

        }};


            var mockRepo = new Mock<ISeatRepository>();

            mockRepo.Setup(c => c.GetAll()).ReturnsAsync(seats);

            mockRepo.Setup(c => c.Add(It.IsAny<Seat>())).ReturnsAsync((Seat seat) =>
            {
                seat.Id = seats.Count() + 1;
                seats.Add(seat);
                return seat;
            });

            mockRepo.Setup(c => c.Update(It.IsAny<Seat>())).Callback((Seat seat) =>
            {
                var newSeats = seats.Where((c) => c.Id != seat.Id);
                seats = newSeats.ToList();
                seats.Add(seat);
            });

            mockRepo.Setup(c => c.Delete(It.IsAny<Seat>())).Callback((Seat seat) =>
            {
                seats.Remove(seat);

            });

            mockRepo.Setup(c => c.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
                {
                    return seats.FirstOrDefault((c) => c.Id == id);
                });

            return mockRepo;
        }


    }

}
