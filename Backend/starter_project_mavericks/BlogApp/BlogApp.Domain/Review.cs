using BlogApp.Domain.Common;

public class Review : BaseDomainEntity
{
    
    public string ReviewerId { get; set; }

    public string Comment { get; set; }
    public bool IsResolved { get; set; } = false;
     public  int  BlogId { get; set; }
}