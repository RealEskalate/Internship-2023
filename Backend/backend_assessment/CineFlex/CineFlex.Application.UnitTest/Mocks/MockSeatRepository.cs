using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using Moq;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockSeatRepository
    {
        public static Mock<ISeatRepository> GetSeatRepository()
        {
            var Seats = new List<Seat>
            {
                 new Seat
                {
                     Id=1,
                     Cinema = new CinemaEntity(),
                     Free = true,
                     SeatNo = 1,
                 },

                new Seat
                {
                     Id=2,
                     Cinema = new CinemaEntity(),
                     Free = true,
                     SeatNo = 2,
                 },
             
            };

            var mockRepo = new Mock<ISeatRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Seats);

            mockRepo.Setup(r => r.Add(It.IsAny<Seat>())).ReturnsAsync((Seat Seat) =>
            {
                Seat.Id = Seats.Count() + 1;
                Seats.Add(Seat);
                return Seat;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Seat>())).Callback((Seat Seat) =>
            {
                var newSeats = Seats.Where((r) => r.Id != Seat.Id);
                Seats = newSeats.ToList();
                Seats.Add(Seat);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Seat>())).Callback((Seat Seat) =>
            {
                Seats.Remove(Seat);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var Seat = Seats.FirstOrDefault((r) => r.Id == Id);
                return Seat != null;
            });


            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {   
                return Seats.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}
