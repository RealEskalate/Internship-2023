﻿using BlogApp.Application.Contracts.Persistence;
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
        var mockBlogRepository = MockBlogRepository.GetBlogRepository();

        var mockCommentRepository = MockCommentRepository.GetCommentRepository();
        var mockReviewRepository = MockReviewRepository.GetReviewRepository();       
        var mockTagRepository = MockTagRepository.GetTagRepository();


        mockUow.Setup(c=>c.CommentRepository).Returns(mockCommentRepository.Object);
        mockUow.Setup(r => r.RatingRepository).Returns(mockRatingRepository.Object);
        mockUow.Setup(uow => uow.BlogRepository).Returns(mockBlogRepository.Object);
        mockUow.Setup(uow => uow.ReviewRepository).Returns(mockReviewRepository.Object);
        mockUow.Setup(uow => uow.TagRepository).Returns(mockTagRepository.Object);
        mockUow.Setup(r => r.Save()).ReturnsAsync(1);
        
        

        return mockUow;
    }
}
