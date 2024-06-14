using CineFlex.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Tests.Mocks;
using CineFlex.Tests.Mocks;

namespace CineFlex.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockSeatRepo = MockSeatsRepository.GetSeatsRepository();
            
            return mockUow;
        }
    }
}

