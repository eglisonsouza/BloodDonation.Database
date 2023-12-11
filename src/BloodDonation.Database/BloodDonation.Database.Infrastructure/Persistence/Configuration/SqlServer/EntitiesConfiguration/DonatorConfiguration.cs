using BloodDonation.Database.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public class DonatorConfiguration : BaseConfiguration<Donator>, IEntityTypeConfiguration<Donator>
    {
        public new void Configure(EntityTypeBuilder<Donator> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .HasIndex(p => p.Email)
                .IsUnique();

            builder
                .Property(p => p.BirthDate)
                .IsRequired();

            builder
                .Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(15);
            builder
                .Property(p => p.Weight)
                .IsRequired()
                .HasMaxLength(3);

            builder
                .Property(p => p.BloodType)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(p => p.RhFactor)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .HasMany(p => p.Addresses)
                .WithOne(p => p.Donator)
                .HasForeignKey(p => p.DonatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(p => p.Donations)
                .WithOne(p => p.Donator)
                .HasForeignKey(p => p.DonatorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
