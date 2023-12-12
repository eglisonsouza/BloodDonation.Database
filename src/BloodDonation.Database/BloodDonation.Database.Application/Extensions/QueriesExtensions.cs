using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel>, FindByZipCodeHandler>();
            services.AddTransient<IRequestHandler<AddDonatorCommand, DonatorViewModel>, AddDonatorHandler>();
            return services;
        }
    }
}
