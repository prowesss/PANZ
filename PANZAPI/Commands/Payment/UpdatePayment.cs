using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Commands.Payment
{
    public class UpdatePayment : IRequest<bool>
    {
        public Guid PaymentId { get; }
        public PaymentMethod UpdatedPayment { get; }

        public UpdatePayment(Guid paymentId, PaymentMethod updatedPayment)
        {
            PaymentId = paymentId;
            UpdatedPayment = updatedPayment;
        }
    }

}
