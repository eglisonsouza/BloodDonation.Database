using BloodDonation.Database.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer.EntitiesConfiguration
{
    public class BloodStockConfiguration : BaseConfiguration<BloodStock>, IEntityTypeConfiguration<BloodStock>
    {
        public new void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.BloodType)
                .IsRequired();

            builder
                .Property(p => p.RhFactor)
                .IsRequired()
                .HasMaxLength(1);
            builder
                .Property(p => p.QuantityMl)
                .IsRequired();
            builder
                .ToTable("BloodStocks");
        }
    }
}
