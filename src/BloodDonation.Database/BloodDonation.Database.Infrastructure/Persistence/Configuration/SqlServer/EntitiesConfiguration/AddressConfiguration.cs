using BloodDonation.Database.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer.EntitiesConfiguration
{
    public class AddressConfiguration : BaseConfiguration<Address>, IEntityTypeConfiguration<Address>
    {
        public new void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(10);
            builder
                .Property(p => p.City)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.State)
                .HasMaxLength(50);
            builder
                .Property(p => p.ZipCode)
                .IsRequired()
                .HasMaxLength(10);
            builder
                .Property(p => p.DonatorId)
                .IsRequired();
            builder
                .HasOne(p => p.Donator)
                .WithMany(p => p.Addresses)
                .HasForeignKey(p => p.DonatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable("Addresses");
        }
    }
}
