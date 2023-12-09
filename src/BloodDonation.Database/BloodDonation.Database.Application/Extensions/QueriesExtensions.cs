using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;
using BloodDonation.Database.Application.ViewModels;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Database.Application.Extensions
{
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel>, FindByZipCodeHandler>();
            return services;
        }
    }
}
