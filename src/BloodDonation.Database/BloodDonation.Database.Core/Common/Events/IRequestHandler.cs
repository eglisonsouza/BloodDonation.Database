namespace BloodDonation.Database.Core.Common.Events
{
    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
