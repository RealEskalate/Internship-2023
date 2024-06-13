
using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
	public class Post : BaseDomainEntity
	{
		public string Title { get; set; } 
		public string Content { get; set; }
		public int UserId { get; set; } 
	}
	
}

//  ID, Title, Content, User ID (foreign key)