namespace PlantHere.Application.Interfaces.Requests
{
    public interface IIdentifiableRequest<out TRequest> : IRequest<TRequest>
    {
        Guid RequestId { get; }
    }
}
