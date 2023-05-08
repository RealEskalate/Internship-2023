using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Mocks
{
    public static class MockTagRepository
    {

        public static Mock<ITagRepository> GetTagRepository()
        {


            var tags = new List<Tag>
            {
                new Tag { 
                    Id = 1,
                    Title = "Java",
                    Description ="this is a tag for Java" 

                },
                 new Tag {
                    Id = 2,
                    Title = "Python",
                    Description ="this is a tag for python"

                },
                  new Tag {
                    Id = 3,
                    Title = "C#",
                    Description ="this is a tag for c#"

                }

            };



            var mockRepo = new Mock<ITagRepository>();

            mockRepo.Setup(t => t.GetAll()).ReturnsAsync(tags);
            mockRepo.Setup(t => t.Add(It.IsAny<Tag>())).ReturnsAsync((Tag tag) =>
            {
                tag.Id = tags.Count() + 1;
                tags.Add(tag);
                MockUnitOfWork.changes += 1;
                return tag;
            });

            mockRepo.Setup(t => t.Update(It.IsAny<Tag>())).Callback((Tag tag) =>
            {
                var newTags = tags.Where((t) => t.Id != tag.Id);
                tags = newTags.ToList();
                tags.Add(tag);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(t => t.Delete(It.IsAny<Tag>())).Callback((Tag tag) =>
            {
                if (tags.Remove(tag))
                    MockUnitOfWork.changes += 1;
            });


            mockRepo.Setup(t => t.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var tag = tags.FirstOrDefault(t => t.Id == Id);

                return tag != null;
            });

            mockRepo.Setup(t => t.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return tags.FirstOrDefault(t => t.Id == Id);
            });


            return mockRepo;




        }

    }
}
