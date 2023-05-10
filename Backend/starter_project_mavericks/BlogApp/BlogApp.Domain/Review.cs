using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Domain;

public class Review
{
    public int Id { get; set; }
    [Required]
    public int BlogId { get; set; }
    [Required]
    public int ReviewerId { get; set; }
    [Required]
    public string Comment { get; set; }
    [DefaultValue(false)]
    public bool IsResolved { get; set; }
}