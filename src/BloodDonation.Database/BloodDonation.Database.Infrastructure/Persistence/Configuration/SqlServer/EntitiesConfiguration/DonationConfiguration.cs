using BloodDonation.Database.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public class DonationConfiguration : BaseConfiguration<Donation>, IEntityTypeConfiguration<Donation>
    {
        public new void Configure(EntityTypeBuilder<Donation> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.DonatorId)
                .IsRequired();
            builder
                .Property(p => p.DonationDate)
                .IsRequired();
            builder
                .Property(p => p.QuantityMl)
                .IsRequired();
            builder
                .HasOne(p => p.Donator)
                .WithMany(p => p.Donations)
                .HasForeignKey(p => p.DonatorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .ToTable("Donations");
        }
    }
}
