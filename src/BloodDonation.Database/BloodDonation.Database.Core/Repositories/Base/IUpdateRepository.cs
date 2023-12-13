using BloodDonation.Database.Core.Models.Entities.Base;

namespace BloodDonation.Database.Core.Repositories.Base
{
    public interface IUpdateRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Update(TEntity entity);
    }
}
