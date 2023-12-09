﻿using System.Text.Json.Serialization;

namespace BloodDonation.Database.Infrastructure.Services.ZipCode.Models
{
    public class ZipCodeExternalModel
    {
        [JsonPropertyName("cep")]
        public string? Cep { get; set; }
        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }
        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }
        [JsonPropertyName("localidade")]
        public string? Localidade { get; set; }
        [JsonPropertyName("uf")]
        public string? Uf { get; set; }
    }
}
