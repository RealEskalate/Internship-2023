using CineFlex.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Identity;
public class CineFlexDbIdentityContext : IdentityDbContext<ApplicationUser>
{
    public CineFlexDbIdentityContext(DbContextOptions<CineFlexDbIdentityContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineFlexDbIdentityContext).Assembly);
    }
}