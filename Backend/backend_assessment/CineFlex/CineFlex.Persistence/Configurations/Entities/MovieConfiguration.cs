using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Configurations.Entities
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Sample Movie 1",
                    ReleaseYear = "1999",
                    
                },
                new Movie
                {
                    Id = 2,
                    Title = "Sample Movie 2",
                    ReleaseYear = "2022",
                    
                }
            );
        }
    }
}