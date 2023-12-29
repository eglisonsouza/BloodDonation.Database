using BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock;
using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;
using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator;
using BloodDonation.Database.Application.Query.DonationEvents.Models;
using BloodDonation.Database.Application.Query.StockEvents.GetLowStock;
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
            services.AddTransient<IRequestHandler<GetLowStockQuery, List<BloodStockViewModel>>, GetLowStockHandler>();
            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddDonatorCommand, DonatorViewModel>, AddDonatorHandler>();
            services.AddTransient<IRequestHandler<AddDonationCommand, DonationViewModel>, AddDonationHandler>();
            services.AddTransient<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>, UpdateBloodStockHandler>();
            services.AddTransient<IRequestHandler<FindDonationsByIdDonatorQuery, DonatorWithDonationsViewModel>, FindDonationsByIdDonatorHandler>();

            return services;
        }
    }
}
