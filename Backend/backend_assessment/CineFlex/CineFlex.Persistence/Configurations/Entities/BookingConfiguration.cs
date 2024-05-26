using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Configurations.Seeds
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking
                {
                    Id = 1,
                    BookingTime = DateTime.Now,
                    TotalPrice = 20.0m,
                    MovieId = 1
                },
                new Booking
                {
                    Id = 2,
                    BookingTime = DateTime.Now,
                    TotalPrice = 30.0m,
                    MovieId = 2
                }
            );
        }
    }
}