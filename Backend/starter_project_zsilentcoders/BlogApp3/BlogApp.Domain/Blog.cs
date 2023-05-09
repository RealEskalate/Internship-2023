using BlogApp.Domain.Common;

namespace BlogApp.Domain;

public enum PublicationStatuses
{
    Published,
    NotPublished
};

public class Blog: BaseDomainEntity
{
    public int Id {get; set;}
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? ThumbnailImage { get; set; }
    public PublicationStatuses PublicationStatus { get; set; }

    // public int TotalRaters {get; set;}
    // public  int TotalRating {get; set;}
    
    // public List<Tag> Tags { get; set; }
    // public List<Comment> Comments { get; set; }
    // public List<Rating> Ratings { get; set; }
    // public List<Review> Reviews { get; set; }
} 