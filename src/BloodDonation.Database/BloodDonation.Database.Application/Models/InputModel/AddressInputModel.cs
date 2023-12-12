using BloodDonation.Database.Core.Entities;

namespace BloodDonation.Database.Application.Models.InputModel
{
    public class AddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Zone { get; set; }

        public static List<Address> ToEntity(List<AddressInputModel> addresses, Guid donatorId)
        {
            return addresses.Select(a => a.ToEntity(donatorId)).ToList();
        }

        public Address ToEntity(Guid donatorId)
        {
            return new Address()
            {
                Street = Street,
                Number = Number,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Zone = Zone,
                DonatorId = donatorId

            };
        }
    }
}
