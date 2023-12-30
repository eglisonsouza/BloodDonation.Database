using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Database.Application.Query.DonationEvents.GetHistoryDonation
{
    public class GetHistoryDonationHandler(IDonationRepository donationRepository) : IRequestHandler<GetHistoryDonationQuery, List<HistoryDonationViewModels>>
    {
        private readonly IDonationRepository _donationRepository = donationRepository;
        public async Task<List<HistoryDonationViewModels>> Handle(GetHistoryDonationQuery request)
        {
            var history = await _donationRepository.GetHistory(request.StartDate, request.EndDate);

            return HistoryDonationViewModels.FromEntity(history);
        }
    }
}
