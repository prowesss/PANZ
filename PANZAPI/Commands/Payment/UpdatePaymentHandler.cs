using MediatR;
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Commands.Payment
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePayment, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePaymentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePayment request, CancellationToken cancellationToken)
        {

            _context.Entry(request.UpdatedPayment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

    }

}
