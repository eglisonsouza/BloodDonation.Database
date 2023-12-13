﻿using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Repositories.Base;

namespace BloodDonation.Database.Core.Repositories
{
    public interface IDonationRepository : IAddRepository<Donation>
    {
        Task<Donation> GetByDonatorIdAsync(Guid id);
    }
}