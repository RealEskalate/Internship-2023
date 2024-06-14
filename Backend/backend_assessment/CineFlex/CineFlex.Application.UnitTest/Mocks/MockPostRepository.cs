using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Moq;

namespace CineFlex.Application.UnitTest.Mocks
{
    public static class MockPostRepository
    {
        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = new List<Post>{
                new Post(){
                    Id = 1,
                    Title = "A2sv Tutorials",
                    Content = "hello",
                    UserId= 1
                }
                ,
                new Post(){
                    Id=2,
                    Title = "Ai and the fate of the future",
                    Content = "World",
                    UserId = 1
                },
                new Post(){
                    Id= 3,
                    Title= "Devil is not the only enemy",
                    Content="given"

                }

            };

            var mockRepo = new Mock<IPostRepository>();
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var post = posts.FirstOrDefault(p => p.Id == id);
                return post;
            });

            mockRepo.Setup(r=>r.GetAll()).ReturnsAsync(posts);

            mockRepo.Setup(r=>r.Add(It.IsAny<Post>())).ReturnsAsync((Post post)=>{
                posts.Add(post);
                return post;
            });

            mockRepo.Setup(p=>p.Update(It.IsAny<Post>())).Callback((Post post)=>{
                var newPost = posts.FirstOrDefault(p=>p.Id==post.Id);
                if(newPost !=null){
                    newPost.Title = post.Title;
                    newPost.Content = post.Content;
                }

            });

            mockRepo.Setup(p=>p.Delete(It.IsAny<Post>())).Callback((Post post)=>{
                var newPost = posts.FirstOrDefault(p=>p.Id==post.Id);
                if(newPost != null){
                    posts.Remove(newPost);
                }
            });

        return mockRepo;
        }

    }
}