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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(
                new Seat
                {
                    Id = 1,
                    RowNumber = 1,
                    SeatNumber = 1,
                    SeatType = "Standard",
                    Availability = true,
                    Price = 10.0m,
                    CinemaHallId = 1, 
                    BookingId = 1
                },
                new Seat
                {
                    Id = 2,
                    RowNumber = 1,
                    SeatNumber = 2,
                    SeatType = "Standard",
                    Availability = true,
                    Price = 10.0m,
                    CinemaHallId = 1,
                    BookingId = 2
                }
            );
        }
    }
}