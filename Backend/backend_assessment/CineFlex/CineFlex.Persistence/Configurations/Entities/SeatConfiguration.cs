using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Persistence.Configurations.Entities
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(
             new Seat
             {
                 Id = 1,
                 IsBooked = true,
                 SeatNumber = 1
             },

            new Seat
            {
                Id = 2,
                IsBooked = false,
                SeatNumber = 2

            });
        }
    }
}