﻿using BloodDonation.Database.Core.Models.Entities.Base;

namespace BloodDonation.Database.Core.Repositories.Base
{
    public interface IAddRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}
