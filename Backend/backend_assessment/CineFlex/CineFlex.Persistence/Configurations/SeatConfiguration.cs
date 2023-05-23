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
					SeatNumber = 1,
					SeatType = "VIP",
					isAvailable = true,
					CinemaId = 999,
				},

				 new Seat
				 {   Id = 2,
					 SeatNumber = 2,
					 SeatType = "Regular",
					 isAvailable = false,
					 CinemaId = 44,
				 }
				); ;
		}


	}
}
