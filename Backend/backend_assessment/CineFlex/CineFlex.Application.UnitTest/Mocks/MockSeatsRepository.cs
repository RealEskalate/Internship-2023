using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace CineFlex.Tests.Mocks;

public static class MockSeatRepository
{
    public static Mock<ISeatsRepository> GetTagRepository()
    {
        var Tags = new List<CineFlex.Domain.Seat>
        {
            new ()
            {
                Id=1,
                
            },
            
            new ()
            {
                Id=2,
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
            var newtags = Tags.Where((r) => r.Id != tag.Id);
            Tags = newtags.ToList();
            Tags.Add(tag);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Tag>())).Callback((Domain.Tag tag) =>
        {
            if (Tags.Exists(b => b.Id == tag.Id))
                Tags.Remove(Tags.Find(b => b.Id == tag.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var rate = Tags.FirstOrDefault((r) => r.Id == id);
            return rate != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Tags.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}