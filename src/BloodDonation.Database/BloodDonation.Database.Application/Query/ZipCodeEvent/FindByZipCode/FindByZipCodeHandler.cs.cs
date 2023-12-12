using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Services;

namespace BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode
{
    public class FindByZipCodeHandler(IZipCodeServiceProxy zipCodeService) : IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel>
    {
        private readonly IZipCodeServiceProxy _zipCodeService = zipCodeService;

        public async Task<ZipCodeViewModel> Handle(FindByZipCodeQuery request)
        {
            var address = await _zipCodeService.GetByZipCodeAsync(request.ZipCode!);
            return ZipCodeViewModel.FromDto(address);
        }
    }
}
