using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace CineFlex.Tests.Mocks;

public static class MockSeatsRepository
{
    public static Mock<ISeatsRepository> GetSeatsRepository()
    {
        var Seats = new List<CineFlex.Domain.Seat>
        {
            new ()
            {
                Id=1,
                CinemaId = 1,
                RowNumber = 3,
                SeatNumber = 4,
                IsOccupied = true,
                SeatType = "",
                Price = 300, 
            },
            
            new ()
            {
                Id=2,
                CinemaId = 2,
                RowNumber = 3,
                SeatNumber = 4,
                IsOccupied = true,
                SeatType = "",
                Price = 300, 
            }
        };

        var mockRepo = new Mock<ISeatsRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Seats);
        
        mockRepo.Setup(r => r.Add(It.IsAny<CineFlex.Domain.Seat>())).ReturnsAsync((CineFlex.Domain.Seat seat) =>
        {
            seat.Id = Seats.Count() + 1;
            Seats.Add(seat);
            return seat; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Seat>())).Callback((Domain.Seat seat) =>
        {
            var newseats = Seats.Where((r) => r.Id != seat.Id);
            Seats = newseats.ToList();
            Seats.Add(seat);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Seat>())).Callback((Domain.Seat seat) =>
        {
            if (Seats.Exists(b => b.Id == seat.Id))
                Seats.Remove(Seats.Find(b => b.Id == seat.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var rate = Seats.FirstOrDefault((r) => r.Id == id);
            return rate != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Seats.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}