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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(
                new Seat
                {
                    Id = 1,
                    CinemaId = 1,
                    Available = true,
                    SeatLocation = "55C"
                },

                new Seat
                {
                    Id = 2,
                    CinemaId = 1,
                    Available = true,
                    SeatLocation = "56C"
                },

                new Seat
                {
                    Id = 3,
                    CinemaId = 1,
                    Available = false,
                    SeatLocation = "55D"
                },

                new Seat
                {
                    Id = 4,
                    CinemaId = 1,
                    Available = false,
                    SeatLocation = "55D"
                },

                new Seat
                {
                    Id = 5,
                    CinemaId = 2,
                    Available = true,
                    SeatLocation = "55A"
                }

                ); 
        }


    }
}
