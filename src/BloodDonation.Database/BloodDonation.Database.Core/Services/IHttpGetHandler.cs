namespace BloodDonation.Database.Core.Services
{
    public interface IHttpGetHandler
    {

        Task<string> GetAsync(string url);

    }
}
