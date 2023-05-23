using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Moq;

namespace CineFlex.Tests.Mocks;

public class MockSeatRepository
{

    public static Mock<ISeatRepository> GetSeatRepository()
    {

        var Seats = new List<CineFlex.Domain.Seat>
        {
            new Domain.Seat()
            {
                Id = 1,
                CinemaId = 1,
                Available = true,
                SeatLocation = "55D"
            },

            new Domain.Seat()
            {
                Id = 2,
                CinemaId = 1,
                Available = false,
                SeatLocation = "55D"
            },
        };

        var mockRepo = new Mock<ISeatRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Seats);

        mockRepo.Setup(r => r.Add(It.IsAny<Domain.Seat>())).ReturnsAsync((Domain.Seat Seat) =>
        {
            Seat.Id = Seats.Count() + 1;
            Seats.Add(Seat);
            return Seat;
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Seat>())).Callback((Domain.Seat Seat) =>
        {
            var newSeats = Seats.Where((r) => r.Id != Seat.Id);
            Seats = newSeats.ToList();
            Seats.Add(Seat);
        });

        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Seat>())).Callback((Domain.Seat Seat) =>

        {
            if (Seats.Exists(b => b.Id == Seat.Id))
                Seats.Remove(Seats.Find(b => b.Id == Seat.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
       {
           var Seat = Seats.FirstOrDefault((r) => r.Id == id);
           return Seat != null;
       });


        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Seats.FirstOrDefault((r) => r.Id == id);
        });

        mockRepo.Setup(r => r.GetWithDetail(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Seats.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}