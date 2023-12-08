﻿using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Database.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddContextSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));

            return services;
        }
    }
}