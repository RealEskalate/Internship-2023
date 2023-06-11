using CineFlex.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.UnitTest.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockPostRepository = MockPostRepository.GetPostRepository();

            mockUow.Setup(uow => uow.PostRepository).Returns(mockPostRepository.Object);
            return mockUow;
        }
    }
}
