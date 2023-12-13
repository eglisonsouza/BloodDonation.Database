using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;
using BloodDonation.Database.Core.Repositories.Base;

namespace BloodDonation.Database.Core.Repositories
{
    public interface IBloodStockRepository : IUpdateRepository<BloodStock>, IAddRepository<BloodStock>
    {
        Task<BloodStock> GetByBloodTypeAndRhFactorAsync(BloodType bloodType, RhFactor rhFactor);
    }
}
