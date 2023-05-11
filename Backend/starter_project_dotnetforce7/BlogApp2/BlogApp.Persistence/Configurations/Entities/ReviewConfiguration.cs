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
    public class ReviewConfiguration: IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    Id = 1,
                    ReviewerId = 1,
                    ReviewContent = "good",
                    BlogId= 2,
                    isResolved = false

                },

                new Review
                {
                    Id = 2,
                    ReviewerId = 3,
                    ReviewContent = "bad",
                    BlogId= 4,
                    isResolved = true
                }
                ); ;
        }
    }
}