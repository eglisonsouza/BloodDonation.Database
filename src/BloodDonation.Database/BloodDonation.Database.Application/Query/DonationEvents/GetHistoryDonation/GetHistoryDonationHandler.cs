using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Repositories.Proxy;

namespace BloodDonation.Database.Application.Query.DonationEvents.GetHistoryDonation
{
    public class GetHistoryDonationHandler(IHistoryDonationProxy historyProxy) : IRequestHandler<GetHistoryDonationQuery, List<HistoryDonationViewModels>>
    {
        private readonly IHistoryDonationProxy _historyProxy = historyProxy;

        public async Task<List<HistoryDonationViewModels>> Handle(GetHistoryDonationQuery request)
        {
            var history = await _historyProxy.GetAsync(request.StartDate, request.EndDate);

            return HistoryDonationViewModels.FromEntity(history!);
        }
    }
}
