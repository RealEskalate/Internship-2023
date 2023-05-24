using MBApp.Domain.Common;


namespace MBApp.Domain

{
	public class Movie : BaseEntity
	{
		public string Title { get; set; }
		public string Genre { get; set; }
		public int ReleaseYear { get; set; }
	}
}
	