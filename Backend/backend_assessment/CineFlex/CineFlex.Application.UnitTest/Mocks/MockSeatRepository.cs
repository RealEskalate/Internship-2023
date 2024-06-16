using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Moq;

namespace CineFlex.Application.UnitTest.Mocks;

public static class MockSeatRepository
{
    public static Mock<ISeatRepository> GetSeatRepository()
    {
        var seats = new List<Seat>
        {
            new ()
            {
                Id=1,
                SeatNumber = 2
                
            },
            
            new ()
            {
                Id=2,
                SeatNumber = 2
               
            }
        };

        var mockRepo = new Mock<ISeatRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(seats);
        
        mockRepo.Setup(r => r.Add(It.IsAny<Seat>())).ReturnsAsync((Seat seat) =>
        {
            seat.Id = seats.Count() + 1;
            seats.Add(seat);
            return seat; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Seat>())).Callback((Seat seat) =>
        {
            var newSeats = seats.Where((r) => r.Id != seat.Id);
            seats = newSeats.ToList();
            seats.Add(seat);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Seat>())).Callback((Seat seat) =>
        {
            if (seats.Exists(b => b.Id == seat.Id))
                seats.Remove(seats.Find(b => b.Id == seat.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var seat = seats.FirstOrDefault((r) => r.Id == id);
            return seat != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return seats.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}