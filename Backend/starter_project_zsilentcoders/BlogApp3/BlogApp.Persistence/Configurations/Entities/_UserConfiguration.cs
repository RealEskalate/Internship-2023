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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Abebe",
                    LastName = "kebede",
                    AccountId = "abe1"
                },

                new User
                {
                    Id = 2,
                    FirstName = "Alemu",
                    LastName = "Lula",
                    AccountId = "Lula1"
                }
                );
        }

    }
}
