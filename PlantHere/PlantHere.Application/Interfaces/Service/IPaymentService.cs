namespace PlantHere.Application.Interfaces.Service
{
    public interface IPaymentService
    {
        CustomResult<bool> ReceiverPayment(int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName);
    }
}
