using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Infrastructure.Persistence.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(
                new Seat
                {
                    Id = 1,
                    Row = 1,
                    Number = 1,
                    IsReserved = false,
                    SeatLevel = "VIP",
                    CinemaId = 1
                },
                new Seat
                {
                    Id = 2,
                    Row = 1,
                    Number = 2,
                    IsReserved = true,
                    SeatLevel = "Regular",
                    CinemaId = 1
                }
            );
        }
    }
}
