﻿using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.UnitTest.Mocks;
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
        public static int changes = 0;
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {   var mockUow = new Mock<IUnitOfWork>();
            var mockRateRepo = MockRateRepository.GetRateRepository();

            mockUow.Setup(r => r.RateRepository).Returns(mockRateRepo.Object);

            mockUow.Setup(r => r.Save()).ReturnsAsync(() =>
            {
                var temp = changes;
                changes = 0;
                return temp;
            });

    
            var mockBlogRepo = MockBlogRepository.GetBlogRepository();

            mockUow.Setup(r => r.BlogRepository).Returns(mockBlogRepo.Object);
            return mockUow;

    }

     
}
}
