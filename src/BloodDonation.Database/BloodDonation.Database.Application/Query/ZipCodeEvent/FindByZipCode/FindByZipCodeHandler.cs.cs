using BloodDonation.Database.Application.ViewModels;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Services;

namespace BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode
{
    public class FindByZipCodeHandler : IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel>
    {
        private readonly IZipCodeSeriviceProxy _zipCodeService;

        public FindByZipCodeHandler(IZipCodeSeriviceProxy zipCodeService)
        {
            _zipCodeService = zipCodeService;
        }

        public async Task<ZipCodeViewModel> Handle(FindByZipCodeQuery request)
        {
            var address = await _zipCodeService.GetByZipCodeAsync(request.ZipCode!);
            return ZipCodeViewModel.FromDto(address);
        }
    }
}
