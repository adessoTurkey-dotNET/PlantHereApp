namespace PlantHere.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        bool ReceiverPayment(int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName);
    }
}
