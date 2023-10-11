using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetPaymentById : IRequest<PaymentMethod>
    {
        public Guid PaymentId { get; }

        public GetPaymentById(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
