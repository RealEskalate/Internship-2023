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
    public class RateConfiguration: IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasData(
                new Rate
                {
                    Id = 1,
                    RaterId = 1,
                    BlogId = 1,
                    RateNo= 5
                },

                new Rate
                {
                    Id = 2,
                    RaterId = 2,
                    BlogId = 2,
                    RateNo = 3
                }
                ); ;
        }
    }
}