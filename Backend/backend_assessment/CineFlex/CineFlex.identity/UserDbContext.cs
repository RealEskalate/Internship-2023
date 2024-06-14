using CineFlex.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.identity
{
    public class UserIdentityDbContext : IdentityDbContext<User>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserIdentityDbContext).Assembly);
        }
    }
}
