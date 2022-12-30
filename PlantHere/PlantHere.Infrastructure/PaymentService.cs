

using PlantHere.Application.CQRS.Results;
using PlantHere.Application.Interfaces.Service;

namespace PlantHere.Infrastructure
{
    public class PaymentService : IPaymentService
    {
        CustomResult<bool> IPaymentService.ReceiverPayment(int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            return CustomResult<bool>.Success(200, true);
        }
    }
}
