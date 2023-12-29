using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Models.Config;
using BloodDonation.Database.Core.Repositories;

namespace BloodDonation.Database.Application.Query.StockEvents.GetLowStock
{
    public class GetLowStockHandler(IBloodStockRepository repository, AppSettings appSettings) : IRequestHandler<GetLowStockQuery, List<BloodStockViewModel>>
    {
        private readonly IBloodStockRepository _repository = repository;
        private readonly StockSettings _settings = appSettings.Stock!;

        public async Task<List<BloodStockViewModel>> Handle(GetLowStockQuery request)
        {
            var bloodStock = await _repository.GetAllByQuantityMl(_settings.LowQuantityInMl);

            return BloodStockViewModel.FromEntity(bloodStock);
        }
    }
}
