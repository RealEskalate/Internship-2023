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
    public class MovieBookingConfiguration : IEntityTypeConfiguration<MovieBooking>
    {
        public void Configure(EntityTypeBuilder<MovieBooking> builder)
        {
            builder.HasData(
                new MovieBooking
                {
                    Id = 1,
                    UserId = "efa06a55-d0cc-4e01-abbf-870f21d91441",
                    MovieId = 1,
                    CinemaId = 1,
                    SeatId = 3
                },

                new MovieBooking
                {
                    Id = 2,
                    UserId = "efa06a55-d0cc-4e01-abbf-870f21d91441",
                    MovieId = 2,
                    CinemaId = 1,
                    SeatId = 4
                }
                ); ;
        }


    }
}
