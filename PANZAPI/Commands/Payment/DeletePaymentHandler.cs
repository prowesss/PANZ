using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Commands.Payment
{
    public class DeletePaymentHandler : IRequestHandler<DeletePayment, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeletePaymentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePayment request, CancellationToken cancellationToken)
        {
            var payment = await _context.PaymentMethods.FindAsync(request.PaymentId);

            if (payment == null)
            {
                return false;
            }

            payment.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
