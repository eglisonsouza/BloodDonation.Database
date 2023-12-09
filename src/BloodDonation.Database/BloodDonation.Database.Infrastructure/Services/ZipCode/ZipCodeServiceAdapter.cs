using BloodDonation.Database.Core.Models.DTOs;
using BloodDonation.Database.Infrastructure.Services.ZipCode.Models;
using System.Text.Json;

namespace BloodDonation.Database.Infrastructure.Services.ZipCode
{
    public class ZipCodeServiceAdapter
    {
        public static ZipCodeDto CreateAddress(string res)
        {
            var externalModel = JsonSerializer.Deserialize<ZipCodeExternalModel>(res);

            return new ZipCodeBuilder().Start()
                .WithZipCode(externalModel!.Cep!)
                .WithCity(externalModel!.Localidade!)
                .WithState(externalModel!.Uf!)
                .WithStreet(externalModel!.Logradouro!)
                .WithZone(externalModel!.Bairro!)
                .Build();
        }
    }
}
