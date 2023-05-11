

using BlogApp.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Configurations.Entities
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    Content = "Sample Content",
                    UserId = 1,
                    BlogId = 1,
                },

                 new Comment
                 {
                     Id = 2,
                     Content = "Sample Content",
                     UserId = 2,
                     BlogId = 2,
                 }
                ); ;
        }


    }
}