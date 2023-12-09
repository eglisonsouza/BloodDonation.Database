using BloodDonation.Database.Core.Services;

namespace BloodDonation.Database.Infrastructure.Services.HttpRequest
{
    public class HttpHandler : IHttpGetHandler
    {
        public async Task<string> GetAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await new HttpClient().SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
