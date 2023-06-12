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
    public class TaskCheckListConfiguration : IEntityTypeConfiguration<TaskCheckListEntity>
    {
        public void Configure(EntityTypeBuilder<TaskCheckListEntity> builder)
        {
            builder.HasData(
                new TaskCheckListEntity
                {
                    Id = 1,
                    TaskId = 1,
                    Title = "First title",
                    Description = "First description",
                    isComplete = true,
                },

                 new TaskCheckListEntity
                 {
                     Id = 2,
                     TaskId = 2,
                     Title = "Second checklist title",
                     Description = "First description",
                     isComplete = true,
                 }
                ); ;
        }


    }
}
