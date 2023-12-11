namespace BloodDonation.Database.UnitTest.Mock
{
    public class StringsMock
    {
        public const string ZipCode = "85907439";
        public const string ZipCodeResponseViaCep = @"{
  ""cep"": ""85907-439"",
  ""logradouro"": ""Rua Gasparina Tomazoni"",
  ""complemento"": """",
  ""bairro"": ""Pinheirinho"",
  ""localidade"": ""Toledo"",
  ""uf"": ""PR"",
  ""ibge"": ""4127700"",
  ""gia"": """",
  ""ddd"": ""45"",
  ""siafi"": ""7927""
}";
        public const string ZipCodeServiceUrl = "https://api.viacep.com.br/{0}/json";
    }
}
