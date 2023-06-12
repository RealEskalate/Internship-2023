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
    public class CinemaConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasData(
            new TaskEntity
            {
                Id = 1,
                Title = "sample",
                Description = "sample",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
            });
        }
    }
}
