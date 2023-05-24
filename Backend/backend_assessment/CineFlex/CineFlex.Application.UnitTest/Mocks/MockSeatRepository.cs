using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace CineFlex.Application.UnitTests.Mocks
{
	public static class MockSeatRepository
	{
		public static Mock<ISeatRepository> GetSeatRepository()
		{
			var seats = new List<Seat>
			{
			   new Seat
				{
					Id = 1,
					SeatNumber = 1,
					SeatType = "VIP",
					isAvailable = true,
					CinemaId = 999,
				},

				 new Seat
				 {   Id = 2,
					 SeatNumber = 2,
					 SeatType = "Regular",
					 isAvailable = false,
					 CinemaId = 44,
				 },
				 new Seat
				 {   Id = 3,
					 SeatNumber = 7,
					 SeatType = "Regular",
					 isAvailable = false,
					 CinemaId = 44,
				 }
			};

			var mockRepo = new Mock<ISeatRepository>();

			mockRepo.Setup(r => r.GetAll()).ReturnsAsync(seats);

			mockRepo.Setup(r => r.Add(It.IsAny<Seat>())).ReturnsAsync((Seat Seat) =>
			{   
				Seat.Id = seats.Count() + 1;
				seats.Add(Seat);
				MockUnitOfWork.changes += 1;
				return Seat;
			}); 

			mockRepo.Setup(r => r.Update(It.IsAny<Seat>())).Callback((Seat Seat) =>
			{
				var newSeats = seats.Where((r) => r.Id != Seat.Id);
				seats = newSeats.ToList();
				seats.Add(Seat);
				MockUnitOfWork.changes += 1;
			});

			mockRepo.Setup(r => r.Delete(It.IsAny<Seat>())).Callback((Seat Seat) =>
			{
				if (seats.Remove(Seat))
					MockUnitOfWork.changes += 1;
			});

			mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
			{
				var seat = seats.FirstOrDefault((r) => r.Id == Id);
				return seat != null;
			});


			mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
			{   
				return seats.FirstOrDefault((r) => r.Id == Id);
			});


			return mockRepo;

		}
	}
}
