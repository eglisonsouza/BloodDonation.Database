using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Core.Repositories.Proxy;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using BloodDonation.Database.Infrastructure.Persistence.Repositories;
using BloodDonation.Database.Infrastructure.Persistence.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Repositories.Proxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddContextSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAddRepository<>), typeof(AddRepository<>));
            services.AddScoped(typeof(IGetByIdRepository<>), typeof(GetByIdRepository<>));
            services.AddScoped(typeof(IUpdateRepository<>), typeof(UpdateRepository<>));
            services.AddScoped<IDonatorRepository, DonatorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();
            services.AddScoped<IHistoryDonationProxy, HistoryDonationProxy>();

            return services;
        }
    }
}
