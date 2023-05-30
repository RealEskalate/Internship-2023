using CineFlex.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.UnitTest.Mocks;

  public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();

            var mockSeatRepo = MockSeatRepository.GetSeatRepository();

            mockUow.Setup(r => r.SeatRepository).Returns(mockSeatRepo.Object);

            mockUow.Setup(r => r.Save()).ReturnsAsync(1);
            
            return mockUow;
        }
    }


