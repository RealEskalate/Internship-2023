using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Persistence.Configurations.Entities;

public class SeatConfiguration: IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasData(
            new Seat
            {
                Id = 1,
                SeatNumber = "B04",
                SeatType = SeatType.VIP,
                Availability = Availability.Free,
            },

             new Seat
             {
                 Id = 2,
                 SeatNumber = "C05",
                 SeatType = SeatType.Regular,
                 Availability = Availability.Taken,
             }
            ); ;
    }


}
