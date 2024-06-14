using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace CineFlex.Application.UnitTest.Mocks
{
    public class MockUnitOfWork 
    {
        public static  Mock<IUnitOfWork> GetUnitOfWork(){
            var mockUow = new Mock<IUnitOfWork>();
            var mockPostRepository = MockPostRepository.GetPostRepository();

            mockUow.Setup(uow=>uow.PostRepository).Returns(mockPostRepository.Object);
            return mockUow;
        }
        
    }
}