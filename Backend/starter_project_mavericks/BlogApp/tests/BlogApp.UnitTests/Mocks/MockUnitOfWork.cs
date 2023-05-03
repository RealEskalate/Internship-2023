using BlogApp.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UnitTests.Mocks;
public class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockRatingRepository = MockRatingRepository.GetRatingRepository();

        mockUow.Setup(r => r.RatingRepository).Returns(mockRatingRepository.Object);

        return mockUow;
    }
}
