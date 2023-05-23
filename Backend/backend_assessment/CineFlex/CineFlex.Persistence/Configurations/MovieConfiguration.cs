using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain;

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
                    Title = "Sample Movie",
                    Genre = "Trailer",
                    ReleaseYear = "1999",
                },

                 new Movie
                 {
                     Id = 2,
                     Title = "Sample Movie",
                     Genre = "Sci Fi",
                     ReleaseYear = "2022",
                 }
                ); ;
        }


    }
}
