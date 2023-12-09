using BloodDonation.Database.Core.Models.DTOs;

namespace BloodDonation.Database.Infrastructure.Services.ZipCode.Models
{
    public class ZipCodeBuilder
    {
        private ZipCodeDto? _zipCodeDto;

        public ZipCodeBuilder Start()
        {
            _zipCodeDto = new ZipCodeDto();
            return this;
        }

        public ZipCodeBuilder WithZipCode(string zipCode)
        {
            _zipCodeDto!.ZipCode = zipCode;
            return this;
        }

        public ZipCodeBuilder WithCity(string city)
        {
            _zipCodeDto!.City = city;
            return this;
        }

        public ZipCodeBuilder WithState(string state)
        {
            _zipCodeDto!.State = state;
            return this;
        }

        public ZipCodeBuilder WithStreet(string street)
        {
            _zipCodeDto!.Street = street;
            return this;
        }

        public ZipCodeBuilder WithZone(string zone)
        {
            _zipCodeDto!.Zone = zone;
            return this;
        }

        public ZipCodeDto Build()
        {
            return _zipCodeDto!;
        }
    }
}
