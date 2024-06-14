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
    public class CheckListConfiguration : IEntityTypeConfiguration<CheckList>
    {
        public void Configure(EntityTypeBuilder<CheckList> builder)
        {
            builder.HasData(
                new CheckList
                {
                    Id = 1,
                    Title = "Sample",
                    Description = "Sample",
                    TaskID = 0,
                    status = true,
                },

                 new CheckList
                 {
                     Id = 2,
                     Title = "Sample",
                     Description = "Sample",
                     TaskID = 0,
                     status = true,
                 }
                ); ;
        }


    }
}
