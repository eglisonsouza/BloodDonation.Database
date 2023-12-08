using BloodDonation.Database.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer.EntitiesConfiguration
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.CreatedAt)
                .IsRequired();
            builder
                .Property(p => p.UpdatedAt);
        }
    }
}
