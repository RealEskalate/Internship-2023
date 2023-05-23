using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.UnitTest.Mocks
{
    public class MockSeatRepository
    {
        public static Mock<ISeatRepository> GetSeatRepository()
        {
            var seats = new List<CineFlex.Domain.Seats>{
                new ()
                {
                    Id = 1,
                    Movie = "new movie",
                    cinemaEntity = "new cinima",
                    RowNumber = 1,
                    SeatType = SeatType.VIP,
                    SeatStatus = SeatStatus.Occupied,
                    SeatPrice = 100,
                    SeatDescription = "description",
                    DateTime = DateTime.Now.AddDays(7),
                  },

                 new ()
                 {
                     Id = 2,
                     Movie = "new Movie()",
                     cinemaEntity = "new CinemaEntity()",
                     RowNumber = 1,
                     SeatType = SeatType.VIP,
                     SeatStatus = SeatStatus.Occupied,
                     SeatPrice = 100,
                     SeatDescription = "description",
                     DateTime = DateTime.Now.AddDays(7),
                 }
           };

            var mockRepo = new Mock<ISeatRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(seats);

            mockRepo.Setup(r => r.Add(It.IsAny<CineFlex.Domain.Seats>())).ReturnsAsync((CineFlex.Domain.Seats seat) =>
            {
                seats.Add(seat);
                return seat;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<CineFlex.Domain.Seats>())).Callback((CineFlex.Domain.Seats seat) =>
            {
                var newSeats = seats.Where((r) => r.Id != seat.Id);
                seats = newSeats.ToList();
                seats.Add(seat);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<CineFlex.Domain.Seats>())).Callback((CineFlex.Domain.Seats seat) =>
            {
                if (seats.Exists(b => b.Id == seat.Id))
                    seats.Remove(seats.Find(b => b.Id == seat.Id)!);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var seatId = seats.FirstOrDefault((r) => r.Id == id);
                return seatId != null;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
            {
                return seats.FirstOrDefault((r) => r.Id == id);
            });

            return mockRepo;
        }
    }
}
