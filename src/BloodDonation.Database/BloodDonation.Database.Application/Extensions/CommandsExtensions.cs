using BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock;
using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;
using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Database.Application.Extensions
{
    public static class CommandsExtensions
    {
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