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
    public class _TagConfiguration : IEntityTypeConfiguration<_Tag>
    {
        public void Configure(EntityTypeBuilder<_Tag> builder)
        {
            builder.HasData(
                new _Tag
                {
                    Id = 1,
                    Title = "First Title",
                    Description = "First Description"
                },

                new _Tag
                {
                    Id = 2,
                    Title = "First Title",
                    Description = "Second Description"
                }
            );
        }
    }
}
