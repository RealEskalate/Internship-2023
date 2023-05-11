using BlogApp.Application.Contracts.Persistence;
using Moq;

namespace BlogApp.Tests.Mocks;

public static class MockUserRepository
{
    public static Mock<I_UserRepository> GetUserRepository()
    {
        var users = new List<BlogApp.Domain.User>
        {
            new ()
            {
                Id=1,
                FirstName = "Abebe",
                LastName = "Kebede",
                Email = "Abe@gmail.com",
                AccountId = "abe1"
                
            },
            
            new ()
            {
                Id=2,
                FirstName = "Alemu",
                LastName = "bekele",
                Email = "Alemu@gmail.com",
                AccountId = "alemu1"
               
            }
        };

        var mockRepo = new Mock<I_UserRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(users);
        
        mockRepo.Setup(r => r.Add(It.IsAny<BlogApp.Domain.User>())).ReturnsAsync((BlogApp.Domain.User user) =>
        {
            user.Id = users.Count() + 1;
            users.Add(user);
            return user; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.User>())).Callback((Domain.User user) =>
        {
            var newUsers = users.Where((r) => r.Id != user.Id);
            users = newUsers.ToList();
            users.Add(user);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.User>())).Callback((Domain.User user) =>
        {
            if (users.Exists(b => b.Id == user.Id))
                users.Remove(users.Find(b => b.Id == user.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var user = users.FirstOrDefault((r) => r.Id == id);
            return user != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return users.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}