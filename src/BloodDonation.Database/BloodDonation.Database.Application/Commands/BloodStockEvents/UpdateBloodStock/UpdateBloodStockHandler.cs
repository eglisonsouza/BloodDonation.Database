using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Repositories;

namespace BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock
{
    public class UpdateBloodStockHandler(IBloodStockRepository bloodStockRepository) : IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>
    {
        private readonly IBloodStockRepository _bloodStockRepository = bloodStockRepository;

        public async Task<BloodStockViewModel> Handle(UpdateBloodStockCommand request)
        {
            var bloodStock = await _bloodStockRepository.GetByBloodTypeAndRhFactorAsync(request.BloodType, request.RhFactor);

            if (bloodStock is null)
                return await AddStock(request);

            bloodStock.UpdateStock(request.QuantityMl);

            var entity = _bloodStockRepository.Update(bloodStock);

            return BloodStockViewModel.FromEntity(entity);
        }

        private async Task<BloodStockViewModel> AddStock(UpdateBloodStockCommand request)
        {
            var entity = await _bloodStockRepository.AddAsync(request.ToEntity());

            return BloodStockViewModel.FromEntity(entity);
        }
    }
}
