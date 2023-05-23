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
    public class SeatConfiguration: IEntityTypeConfiguration<Seats>
    {
        public void Configure(EntityTypeBuilder<Seats> builder)
        {
            builder.HasData(
                new Seats
                {
                    Id = 1,
                    Movie = "new movie",
                    cinemaEntity = "new cinima",
                    RowNumber = 1,
                    SeatType = SeatType.VIP,
                    SeatStatus = SeatStatus.Occupied,
                    SeatPrice = 100,
                    SeatDescription = "description",
                    DateTime = DateTime.Now
                  },

                 new Seats
                 {
                     Id = 2,
                     Movie = "new Movie()",
                     cinemaEntity = "new CinemaEntity()",
                     RowNumber = 1,
                     SeatType = SeatType.VIP,
                     SeatStatus = SeatStatus.Occupied,
                     SeatPrice = 100,
                     SeatDescription = "description",
                     DateTime = DateTime.Now
                 }
                );
        }
    }
}
