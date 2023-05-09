using BlogApp.Domain.Common;
using System.Collections;

namespace BlogApp.Domain
{
    public class Blog : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? CoverImage { get; set; }
        public bool? PublicationStatus { get; set; }

        public ICollection<Rate> Rates { get; set; } // One-to-many relationship with Rate

    }
}