using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.UnitTest.Mocks
{
    public static class MockPostRepository
    {
        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = new List<Post>{
                new Post(){
                    Id = 1,
                    Title = "This is backend assessement first",
                    Content = "It contain the description of assessment first",
                    PostUserId= 1
                }
                ,
                new Post(){
                    Id=2,
                    Title = "This is backend assessement second",
                    Content = "It contain the description of assessment second",
                    PostUserId = 1
                },
                new Post(){
                    Id= 3,
                    Title= "This is backend assessement third",
                    Content="It contain the description of assessment third"

                }

            };

            var mockRepo = new Mock<IPostRepository>();

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var post = posts.FirstOrDefault(p => p.Id == id);
                return post;
            });

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(posts);

            mockRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) => {
                posts.Add(post);
                return post;
            });

            mockRepo.Setup(p => p.Update(It.IsAny<Post>())).Callback((Post post) => {
                var newPost = posts.FirstOrDefault(p => p.Id == post.Id);
                if (newPost != null)
                {
                    newPost.Title = post.Title;
                    newPost.Content = post.Content;
                }

            });

            mockRepo.Setup(p => p.Delete(It.IsAny<Post>())).Callback((Post post) => {
                var newPost = posts.FirstOrDefault(p => p.Id == post.Id);
                if (newPost != null)
                {
                    posts.Remove(newPost);
                }
            });

            return mockRepo;
        }
    }
}
