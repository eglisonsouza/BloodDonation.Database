namespace BloodDonation.Database.Core.Services
{
    public interface ICache
    {
        T Get<T>(string key, out T output);
        void Set<T>(string key, T value, TimeSpan? timeToLive = null);
    }
}
