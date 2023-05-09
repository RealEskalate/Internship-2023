using BlogApp.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockUserRepo = MockUserRepository.GetUserRepository();
            mockUow.Setup(r => r._UserRepository).Returns(mockUserRepo.Object);
            return mockUow;
        }
    }


}