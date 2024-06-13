
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
            var Blogs = new List<Seat>
            {
                 new Seat
                {
                    Id = 1,
                    SeatNumber = "008",
                    SeatType = SeatType.VIP,
                    Availability = Availability.Taken,
                    
                },

              new Seat
                {
                    Id = 3,
                    SeatNumber = "008",
                    SeatType = SeatType.Regular,
                    Availability = Availability.Taken,

                },
            };

            var mockRepo = new Mock<ISeatRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Blogs);

            mockRepo.Setup(r => r.Add(It.IsAny<Seat>())).ReturnsAsync((Seat Blog) =>
            {
                Blog.Id = Blogs.Count() + 1;
                Blogs.Add(Blog);
                MockUnitOfWork.changes += 1;
                return Blog;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Seat>())).Callback((Seat Blog) =>
            {
                var newBlogs = Blogs.Where((r) => r.Id != Blog.Id);
                Blogs = newBlogs.ToList();
                Blogs.Add(Blog);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Seat>())).Callback((Seat Blog) =>
            {
                if (Blogs.Remove(Blog))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return Blogs.FirstOrDefault((r) => r.Id == Id);
            });

            return mockRepo;

        }
    }
}