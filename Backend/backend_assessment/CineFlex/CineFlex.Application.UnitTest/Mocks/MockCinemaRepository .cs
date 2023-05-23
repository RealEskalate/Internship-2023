using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using Moq;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockCinemaRepository
    {
        public static Mock<ICinemaRepository> GetCinemaRepository()
        {
            var Seats = new List<CinemaEntity>
            {
                 new CinemaEntity
                {
                     Id=1,
                     },

                new CinemaEntity
                {
                     Id=2,
                 },
             
            };

            var mockRepo = new Mock<ICinemaRepository>();

            /*mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Seats);

            mockRepo.Setup(r => r.Add(It.IsAny<Cinema>())).ReturnsAsync((Cinema Cinema) =>
            {
                Cinema.Id = Seats.Count() + 1;
                Seats.Add(Cinema);
                return Cinema;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Cinema>())).Callback((Cinema Cinema) =>
            {
                var newSeats = Seats.Where((r) => r.Id != Cinema.Id);
                Seats = newSeats.ToList();
                Seats.Add(Cinema);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Cinema>())).Callback((Cinema Cinema) =>
            {
                Seats.Remove(Cinema);
            });*/

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var Cinema = Seats.FirstOrDefault((r) => r.Id == Id);
                return Cinema != null;
            });

/*
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {   
                return Seats.FirstOrDefault((r) => r.Id == Id);
            });
*/

            return mockRepo;

        }
    }
}
