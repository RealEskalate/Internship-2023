using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.UnitTest.Mocks;
using BlogApp.Domain;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockRateRepository
    {
        public static Mock<IRateRepository> GetRateRepository()
        {
            var Rates = new List<Rate>
            {
                 new Rate
                {
                    Id = 1,
                    RaterId = 1,
                    BlogId = 1,
                    RateNo= 5
                },

                new Rate
                {
                    Id = 2,
                    RaterId = 2,
                    BlogId = 2,
                    RateNo = 3
                }
            };

            var mockRepo = new Mock<IRateRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Rates);

            mockRepo.Setup(r => r.Add(It.IsAny<Rate>())).ReturnsAsync((Rate Rate) =>
            {
                Rate.Id = Rates.Count() + 1;
                Rates.Add(Rate);
                MockUnitOfWork.changes += 1;
                return Rate;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Rate>())).Callback((Rate Rate) =>
            {
                var newRates = Rates.Where((r) => r.Id != Rate.Id);
                Rates = newRates.ToList();
                Rates.Add(Rate);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Rate>())).Callback((Rate Rate) =>
            {
                if (Rates.Remove(Rate))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var rate = Rates.FirstOrDefault((r) => r.Id == Id);
                return rate != null;
            });


            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {   
                return Rates.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}
