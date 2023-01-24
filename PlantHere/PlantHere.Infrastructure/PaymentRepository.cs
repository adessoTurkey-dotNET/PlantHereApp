using PlantHere.Application.Interfaces.Repositories;

namespace PlantHere.Infrastructure
{
    public class PaymentRepository : IPaymentRepository
    {
        public bool ReceiverPayment(int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            return true;
        }
    }
}
