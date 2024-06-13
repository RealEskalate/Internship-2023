using CineFlex.Application.Contracts.Persistence;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUoW = new Mock<IUnitOfWork>();
            var mockTaskRepo = MockTaskRepository.GetTaskRepository();

            mockUoW.Setup(c => c.TaskRepository).Returns(mockTaskRepo.Object);

            return mockUoW;

        }

    }
}