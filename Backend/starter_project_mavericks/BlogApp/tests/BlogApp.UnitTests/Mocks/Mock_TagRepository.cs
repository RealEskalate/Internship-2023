using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UnitTests.Mocks
{
    public class Mock_TagRepository
    {
        public static Mock<I_TagRepository> Get_TagRepository()
        {
            var tags = new List<_Tag>{
                new _Tag{
                    Id=1,
                    Title="First Tag Title",
                    Description="This is the description of the first tag"

                },
                new _Tag{
                    Id=2,
                    Title="Second Tag Title",
                    Description="This is the description of the second tag"
                    
                },
                new _Tag{
                    Id=3,
                    Title="Third Tag Title",
                    Description="This is the description of the third tag"
                    
                },
                new _Tag{
                    Id=4,
                    Title="Fourth Tag Title",
                    Description="This is the description of the fourth tag"
                    
                }
            };

            var _tagRepo = new Mock<I_TagRepository>();

            _tagRepo.Setup(repo => repo.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>{
                return tags.Exists(tag => tag.Id == id);
            });

            _tagRepo.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((int id) => tags.FirstOrDefault(o => o.Id == id));
            _tagRepo.Setup(repo => repo.Add(It.IsAny<_Tag>())).ReturnsAsync((_Tag tag) => {
                tag.Id = tags.Count + 1;
                tags.Add(tag);
                return tag;
            });

            _tagRepo.Setup(repo => repo.Delete(It.IsAny<_Tag>()))
                                        .Callback<_Tag>(tag => tags.RemoveAll(b => b.Id == tag.Id));

            _tagRepo.Setup(repo => repo.Update(It.IsAny<_Tag>())).Callback<_Tag>(tag => {
                _Tag? tagTemp = tags.FirstOrDefault(b => b.Id == tag.Id);
                if (tagTemp != null)
                {
                    tagTemp.Title = tag.Title;
                    tagTemp.Description = tag.Description;
       
                }
            });

            return _tagRepo;
        }
    }
}
