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
    public class CinemaConfiguration : IEntityTypeConfiguration<CinemaEntity>
    {
        public void Configure(EntityTypeBuilder<CinemaEntity> builder)
        {
            builder.HasData(
            new CinemaEntity
            {
                Id = 1,
                Name = "First name",
                Location = "First location",
                ContactInformation = "0937363056"
            },

                new CinemaEntity
                {
                    Id = 2,
                    Name = "second name",
                    Location = "second location",
                    ContactInformation = "0937363056"
                });
        }
    }
}
