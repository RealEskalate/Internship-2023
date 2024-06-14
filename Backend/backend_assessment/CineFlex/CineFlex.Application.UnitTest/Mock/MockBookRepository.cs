using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using CineFlex.Application.UnitTest.Mocks;

namespace CineFlex.Application.UnitTest.Mocks
{
    public static class MockTasksRepository
    {
        public static Mock<IBookRepository> GetTasksRepository()
        {
            var books = new List<Domain.Book>
            {
                 new Domain.Book
                {
                    UserId = 1,
                    SeatId = 1,
                    MovieId = 1,
                    Id = 1
                },

                new Domain.Book
                {
                    UserId = 2,
                    SeatId = 2,
                    MovieId = 2,
                    Id = 2
                },
            };

            var mockRepo = new Mock<IBookRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(books);

            mockRepo.Setup(r => r.Add(It.IsAny<Domain.Book>())).ReturnsAsync((Domain.Book book) =>
            {
                book.Id = books.Count() + 1;
                books.Add(book);
                MockUnitOfWork.changes += 1;
                return book;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Domain.Book>())).Callback((Domain.Book book) =>
            {
                var newbook = books.Where((r) => r.Id != book.Id);
                books = newbook.ToList();
                books.Add(book);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Book>())).Callback((Domain.Book book) =>
            {
                if (books.Remove(book))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return books.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}