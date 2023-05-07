using System.ComponentModel.DataAnnotations;
using System;
using BlogApp.Domain.Common;

namespace BlogApp.Domain{

    public enum PublicationStatus{
        Published, 
        NotPublished 
    }

    public class Blog: BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public PublicationStatus Status { get; set; }
        public int Rating { get; set; }
    }
}