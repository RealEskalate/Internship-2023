using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Persistence.Configurations
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasData(
			new Post
			{
				Id = 1,
				Title = "Title for post one",
				Content = "Content for post One",
				UserId = 1,
			},

			new Post
			{   
				Id = 2,
				Title = "Title for post two",
				Content = "Content for post two",
				UserId = 2,
			});
		}
	}
}
