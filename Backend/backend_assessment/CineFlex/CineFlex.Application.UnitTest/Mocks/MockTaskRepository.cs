using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockTaskRepository
    {

        public static Mock<ITaskRepository> GetTaskRepository()
        {

            var Tasks = new List<TaskEntity>
            {
               new TaskEntity
             {
                Id = 1,
                Title = "First title",
                Description = "First description",
                StartDate  = new DateTime(2023, 6, 12, 9, 0, 0),
                EndDate = new DateTime(2023, 6, 15, 17, 30, 0),
                isComplete = true,
             },

            new TaskEntity
            {
                Id = 2,
                Title = "Second title",
                Description = "Second description",
                StartDate  = new DateTime(2023, 6, 12, 9, 0, 0),
                EndDate = new DateTime(2023, 6, 15, 17, 30, 0),
                isComplete = true,

        }};


            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(c => c.GetAll()).ReturnsAsync(Tasks);

            mockRepo.Setup(c => c.Add(It.IsAny<TaskEntity>())).ReturnsAsync((TaskEntity task) =>
            {
                task.Id = Tasks.Count() + 1;
                Tasks.Add(task);
                return task;
            });

            mockRepo.Setup(c => c.Update(It.IsAny<TaskEntity>())).Callback((TaskEntity task) =>
            {
                var newSeats = Tasks.Where((c) => c.Id != task.Id);
                Tasks = newSeats.ToList();
                Tasks.Add(task);
            });

            mockRepo.Setup(c => c.Delete(It.IsAny<TaskEntity>())).Callback((TaskEntity task) =>
            {
                Tasks.Remove(task);

            });

            mockRepo.Setup(c => c.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return Tasks.FirstOrDefault((c) => c.Id == id);
            });

            return mockRepo;
        }


    }

}