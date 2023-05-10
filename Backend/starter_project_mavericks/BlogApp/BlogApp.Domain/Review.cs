using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlogApp.Domain.Common;

namespace BlogApp.Domain;

public class Review : BaseDomainEntity
{
    
    public int BlogId { get; set; }
    
    public string ReviewerId { get; set; }
    
    public string Comment { get; set; }
    public bool IsResolved { get; set; } = false;
}