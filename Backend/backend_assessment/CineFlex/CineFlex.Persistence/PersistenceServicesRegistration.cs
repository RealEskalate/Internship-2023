﻿using CineFlex.Application.Contracts.Persistence;
using CineFlex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;

namespace CineFlex.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CineFlexDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("CineFlexConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IMovieBookingRepository, MovieBookingRepository>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<CineFlexDbContext>().AddDefaultTokenProviders();
            return services;
        }
    }
}