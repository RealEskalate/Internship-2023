using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.UnitTest.Mocks
{
	public static class MockUnitOfWork
	{
		public static int changes = 0;
		public static Mock<IUnitOfWork> GetUnitOfWork()
		{   var mockUow = new Mock<IUnitOfWork>();
			
			
			var mockSeatRepo = MockSeatRepository.GetSeatRepository();
			mockUow.Setup(r => r.SeatRepository).Returns(mockSeatRepo.Object);


	        var mockPostRepo = MockPostRepository.GetPostRepository();
			mockUow.Setup(r => r.PostRepository).Returns(mockPostRepo.Object);


			mockUow.Setup(r => r.Save()).ReturnsAsync(() =>
			{
				var temp = changes;
				changes = 0;
				return temp;
			});

	
		  

			return mockUow;

	}

	 
}
}
