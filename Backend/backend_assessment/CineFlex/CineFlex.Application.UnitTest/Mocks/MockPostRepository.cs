using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace CineFlex.Application.UnitTests.Mocks
{
	public static class MockPostRepository
	{
		public static Mock<IPostRepository> GetPostRepository()
		{
			var posts = new List<Post>
			{
			new Post
			{   
				Id = 1,
				Title = "Title for post two",
				Content = "Content for post two",
				UserId = 1,
			},
			
			new Post
			{   
				Id = 2,
				Title = "Title for post two",
				Content = "Content for post two",
				UserId = 2,
			},

				 
			};

			var mockRepo = new Mock<IPostRepository>();

			mockRepo.Setup(r => r.GetAll()).ReturnsAsync(posts);

			mockRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post Post) =>
			{   
				Post.Id = posts.Count() + 1;
				posts.Add(Post);
				MockUnitOfWork.changes += 1;
				return Post;
			}); 

			mockRepo.Setup(r => r.Update(It.IsAny<Post>())).Callback((Post Post) =>
			{
				var newPosts = posts.Where((r) => r.Id != Post.Id);
				posts = newPosts.ToList();
				posts.Add(Post);
				MockUnitOfWork.changes += 1;
			});

			mockRepo.Setup(r => r.Delete(It.IsAny<Post>())).Callback((Post Post) =>
			{
				if (posts.Remove(Post))
					MockUnitOfWork.changes += 1;
			});

			mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
			{
				var post = posts.FirstOrDefault((r) => r.Id == Id);
				return post != null;
			});


			mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
			{   
				return posts.FirstOrDefault((r) => r.Id == Id);
			});


			return mockRepo;

		}
	}
}
