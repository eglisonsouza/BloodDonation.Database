using BloodDonation.Database.Core.Entities.Base;

namespace BloodDonation.Database.Core.Repositories.Base
{
    public interface IGetByIdRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?>? GetByIdAsync(Guid id);
    }
}
