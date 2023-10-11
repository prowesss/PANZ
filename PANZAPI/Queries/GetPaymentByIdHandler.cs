using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentById, PaymentMethod>
    {
        private readonly ApplicationDbContext _context;

        public GetPaymentByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> Handle(GetPaymentById request, CancellationToken cancellationToken)
        {
            var payment = await _context.PaymentMethods.FindAsync(request.PaymentId);
            return payment;
        }
    }

}
