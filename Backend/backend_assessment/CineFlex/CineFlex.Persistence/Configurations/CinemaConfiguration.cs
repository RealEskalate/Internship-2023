using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(
            new Cinema
            {
                Id = 1,
                Name = "First name",
                Location = "First location",
                ContactInformation = "0937363056"
            },

                new Cinema
                {
                    Id = 2,
                    Name = "second name",
                    Location = "second location",
                    ContactInformation = "0937363056"
                });
        }
    }
}
