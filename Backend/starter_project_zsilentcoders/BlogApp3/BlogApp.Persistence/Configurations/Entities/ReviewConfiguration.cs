using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Configurations.Entities
{
    public class ReviewConfiguration: IEntityTypeConfiguration<_Review>
    {
        public void Configure(EntityTypeBuilder<_Review> builder)
    {
        builder.HasData(
            new _Review
            {
             Id=1,
             BlogId=1,
             ReviewerId=1,
             DateCreated=DateTime.Now,
             LastModifiedDate=DateTime.Now,
             Comment = "this is the first reveiw"
            },

            new _Review
            {
                Id = 2,
                BlogId = 2,
                ReviewerId = 2,
                DateCreated = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Comment = "this is the second reveiw"
            }
            );
    }

}
}
