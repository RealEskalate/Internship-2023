using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain;

namespace BlogApp.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<_Index>
    {
        public void Configure(EntityTypeBuilder<_Index> builder)
        {
            builder.HasData(
                new _Index
                {
                    Id = 1,
                    Name = "First Index"
                },

                new _Index
                {
                    Id = 2,
                    Name = "Second Index"
                }
                );
        }

    }
}
