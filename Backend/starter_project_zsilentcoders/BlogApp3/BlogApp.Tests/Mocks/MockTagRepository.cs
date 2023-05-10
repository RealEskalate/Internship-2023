using BlogApp.Application.Contracts.Persistence;
using Moq;

namespace BlogApp.Tests.Mocks;

public static class MockTagRepository
{
    public static Mock<ITagRepository> GetTagRepository()
    {
        var Tags = new List<BlogApp.Domain.Tag>
        {
            new ()
            {
                Id=1,
                Title = "Title of Tag 1",
                Description = "Description of Tag 1",
            },
            
            new ()
            {
                Id=2,
                Title = "Title of Tag 2",
                Description = "Description of Tag 2",
            }
        };

        var mockRepo = new Mock<ITagRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Tags);
        
        mockRepo.Setup(r => r.Add(It.IsAny<BlogApp.Domain.Tag>())).ReturnsAsync((BlogApp.Domain.Tag tag) =>
        {
            tag.Id = Tags.Count() + 1;
            Tags.Add(tag);
            return tag; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Tag>())).Callback((Domain.Tag tag) =>
        {
            var newtags = Tags.Where((r) => r.Id != tag.Id);
            Tags = newtags.ToList();
            Tags.Add(tag);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Tag>())).Callback((Domain.Tag tag) =>
        {
            if (Tags.Exists(b => b.Id == tag.Id))
                Tags.Remove(Tags.Find(b => b.Id == tag.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var rate = Tags.FirstOrDefault((r) => r.Id == id);
            return rate != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Tags.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}