using BlogApp.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockRateRepo = MockRateRepository.GetRateRepository();
            mockUow.Setup(r => r.RateRepository).Returns(mockRateRepo.Object);
            return mockUow;
        }
    }

     
}
