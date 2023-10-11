using MediatR;

namespace PANZAPI.Commands.Payment
{
    public class DeletePayment : IRequest<bool>
    {
        public Guid PaymentId { get; }

        public DeletePayment(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }

}
