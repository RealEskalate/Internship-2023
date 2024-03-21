using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Persistence.Configurations.Entities
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag
                {
                    Id = 1,
                    Title = "Polititcs",
                    Description = "this is a tag for polititcs",

                },
                   new Tag
                   {
                       Id = 2,
                       Title = "Science",
                       Description = "this is a tag for Science",

                   }
            );
        }
    }
}