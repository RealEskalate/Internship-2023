using AutoMapper.Configuration;
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
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasData(
            new TaskEntity
            {
                Id = 1,
                Title = "First title",
                Description = "First description",
                StartDate  = new DateTime(2023, 6, 12, 9, 0, 0),
                EndDate = new DateTime(2023, 6, 15, 17, 30, 0),
                isComplete = true,
               
            },

                new TaskEntity
                {
                    Id = 2,
                    Title = "Second title",
                    Description = "Second description",
                    StartDate = new DateTime(2023, 7, 12, 9, 0, 0),
                    EndDate = new DateTime(2023, 7, 15, 17, 30, 0)
                });
        }
    }
}
